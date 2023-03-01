using BCH.Domain.Abstractions;
using BCH.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCH.Infrasructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;

        public IBlockchainRepository Repository { get; }

        private IDbContextTransaction _transaction;

        public UnitOfWork(DataContext context, IBlockchainRepository repository)
        {
            Repository = repository;
            _dbContext = context;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.CommitAsync(cancellationToken);
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _transaction?.Dispose();

            _dbContext.Dispose();
        }


    }
}
