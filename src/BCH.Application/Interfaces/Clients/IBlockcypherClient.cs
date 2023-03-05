using BCH.Domain.Primitives;
using BCH.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCH.Application.Interfaces.Clients
{
    public interface IBlockcypherClient
    {
        Task<BCHModel?> GetBCHAsync(BlockchainType type, CancellationToken cancellationToken = default);
    }
}
