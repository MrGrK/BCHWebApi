using BCH.Domain;
using BCH.Infrasructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCH.Infrasructure.Clients.Interfaces
{
    public interface IBlockcypherClient
    {
        Uri ApiBaseUri { get; }

        Task<BCHModel?> GetBCHAsync(BlockchainType type, CancellationToken cancellationToken = default);
    }
}
