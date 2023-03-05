using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCH.Domain.Entities;
using BCH.Domain.Primitives;
using BCH.Domain.ValueObjects;

namespace BCH.Domain.Interfaces.Repositories
{
    public interface IBlockchainRepository
    {
        public Task<List<Info>> GetAllAsync(CancellationToken token);

        public Task<List<Info>> GetByTypeAsync(BlockchainType type, CancellationToken cancellationToken);

        public Task<BchInfo> SaveAsync(BchInfo entity, CancellationToken cancellationToken);
    }
}
