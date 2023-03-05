using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCH.Application.Interfaces.Clients;
using BCH.Domain.Abstractions;
using BCH.Domain.Entities;

using BCH.Domain.Interfaces.Repositories;
using BCH.Application.Models;
using MediatR;
using System.Collections;
using Newtonsoft.Json;
using BCH.Domain.ValueObjects;
using BCH.Application.Queries.GetByDateTime;
using Microsoft.Extensions.Logging;

namespace BCH.Application.Commands.Create
{
    internal class CreateBchInfoCommandHandler : IRequestHandler<CreateBchInfoCommand, BCHModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlockcypherClient _client;
        private readonly ILogger<CreateBchInfoCommandHandler> _logger;

        public CreateBchInfoCommandHandler(IUnitOfWork uow, IBlockcypherClient client, ILogger<CreateBchInfoCommandHandler> logger)
        {
            _unitOfWork = uow;
            _client = client;
            _logger = logger;
        }

        public async Task<BCHModel> Handle(CreateBchInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _client.GetBCHAsync(request.Type, cancellationToken);

                if (result == null)
                {
                    throw new Exception("Null result from client");
                }

                BchInfo entity = new BchInfo()
                {
                    CreateAt = request.CreateAt,
                    Type = request.Type,
                    Info = Info.Create(JsonConvert.SerializeObject(result))
                };

                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var res = await _unitOfWork.Repository.SaveAsync(entity, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                await _unitOfWork.CommitTransactionAsync(cancellationToken);

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
