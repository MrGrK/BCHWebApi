using BCH.Application.Models;
using BCH.Application.Queries.GetByDateTime;
using BCH.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCH.Application.Queries.GetAll
{
    internal class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<BCHModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<GetAllQueryHandler> _logger;
        
        public GetAllQueryHandler(IUnitOfWork uow, ILogger<GetAllQueryHandler> logger)
        {
            _unitOfWork = uow;
            _logger = logger;
        }

        public async Task<IEnumerable<BCHModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new List<BCHModel>();

                var bchInfoList = await _unitOfWork.Repository.GetAllAsync(cancellationToken);

                bchInfoList.ForEach(x =>
                {
                    result.Add(JsonConvert.DeserializeObject<BCHModel>(x.Value));
                });

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.StackTrace);
                throw ex;
            }
        }
    }
}
