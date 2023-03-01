using BCH.Domain.Entities;
using BCH.Domain.Interfaces.Repositories;
using BCH.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCH.Infrasructure.Data.Repositories
{
    public class BlockchainRepository : IBlockchainRepository
    {
        protected readonly DataContext _context;

        public BlockchainRepository(DataContext context)
        {
            _context = context;
        }

        public Task<IQueryable<BchInfo>> GetAllAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<BchInfo>> GetByTypeAsync(BlockchainType type, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<BchInfo> SaveAsync(BchInfo entity, CancellationToken cancellationToken)
        {
            var res = await _context.Set<BchInfo>().AddAsync(entity, cancellationToken);
            return res.Entity;
        }
    }
}
