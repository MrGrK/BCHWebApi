using BCH.Domain.Entities;
using BCH.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCH.Domain.Interfaces.Services
{
    public interface IBlockchainService
    {
        public Task<IQueryable<BchInfo>> GetAllBlockchainAsync(CancellationToken cancellationToken);

        public Task<IQueryable<BchInfo>> GetBlockchainByTypeAsync(BlockchainType type, CancellationToken cancellationToken);

        public Task<BchInfo> SaveInfo(BchInfo blockchain, CancellationToken cancellationToken = default);
    }
}
