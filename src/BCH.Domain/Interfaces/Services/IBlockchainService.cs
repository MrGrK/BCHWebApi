using BCH.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCH.Domain.Interfaces.Services
{
    public interface IBlockchainService
    {
        public Task<IQueryable<Blockchain>> GetAllBlockchainAsync(CancellationToken cancellationToken);

        public Task<IQueryable<Blockchain>> GetBlockchainByTypeAsync(BlockchainType type, CancellationToken cancellationToken);

        public Task<bool> SaveInfo(Blockchain blockchain, CancellationToken cancellationToken = default);
    }
}
