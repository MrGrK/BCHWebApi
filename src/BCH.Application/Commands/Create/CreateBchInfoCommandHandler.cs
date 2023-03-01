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

namespace BCH.Application.Commands.Create
{
    internal class CreateBchInfoCommandHandler : IRequestHandler<CreateBchInfoCommand, BCHModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlockcypherClient _client;

        public CreateBchInfoCommandHandler( IUnitOfWork uow, IBlockcypherClient client)
        {
            _unitOfWork = uow;
            _client = client;
        }

        public async Task<BCHModel> Handle(CreateBchInfoCommand request, CancellationToken cancellationToken)
        {
            var result = await _client.GetBCHAsync(request.Type, cancellationToken);

            if (result == null)
            {
                throw new Exception("Null result from client");
            }

            BchInfo entity = new BchInfo()
            {
                CreateAt= request.CreateAt,
                Bch = new Domain.Entities.BCH() 
                {
                    Name = result.Name,
                    CallTime= result.CallTime,
                    PeerCount= result.PeerCount,
                    UnconfirmedCount= result.UnconfirmedCount,
                    Hash= result.Hash,
                    Height = result.Height,
                    HighFeePerKb= result.HighFeePerKb,
                    LastForkHash= result.LastForkHash,
                    LastForkHeight= result.LastForkHeight,
                    LatestUrl= result.LatestUrl,
                    LowFeePerKb= result.LowFeePerKb,
                    MediumFeePerKb= result.MediumFeePerKb,
                    PreviousHash= result.PreviousHash,
                    PreviousUrl= result.PreviousUrl,
                },
            };

            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var res = await _unitOfWork.Repository.SaveAsync(entity, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                await _unitOfWork.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }
    }
}
