using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCH.Domain.Interfaces.Repositories
{
    public interface IBlockchainRepository
    {
        public Task<IQueryable<Blockchain>> GetAllAsync(CancellationToken token);

        public Task<IQueryable<Blockchain>> GetByTypeAsync(BlockchainType type, CancellationToken cancellationToken);

        public Task<bool> SaveAsync(Blockchain entity, CancellationToken cancellationToken);
    }
}
