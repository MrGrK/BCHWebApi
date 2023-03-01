using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCH.Domain.Entities;
using BCH.Domain.Primitives;

namespace BCH.Domain.Interfaces.Repositories
{
    public interface IBlockchainRepository
    {
        public Task<IQueryable<BchInfo>> GetAllAsync(CancellationToken token);

        public Task<IQueryable<BchInfo>> GetByTypeAsync(BlockchainType type, CancellationToken cancellationToken);

        public Task<BchInfo> SaveAsync(BchInfo entity, CancellationToken cancellationToken);
    }
}
