using BCH.Application.Interfaces.Clients;
using BCH.Application.Models;
using BCH.Domain.Abstractions;
using BCH.Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCH.Application.Queries.GetByDateTime
{
    public class GetByTimestampHandler : IRequestHandler<GetByTimestampQuery, IEnumerable<BCHModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByTimestampHandler(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public async Task<IEnumerable<BCHModel>> Handle(GetByTimestampQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new List<BCHModel>();

                var bchInfoList = await _unitOfWork.Repository.GetByTypeAsync(request.Type, cancellationToken);

                bchInfoList.ForEach(x => 
                {
                    result.Add(JsonConvert.DeserializeObject<BCHModel>(x.Value));
                });

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
