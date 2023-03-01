using BCH.Domain.Interfaces.Services;
using BCH.Domain.Interfaces.Repositories;
using BCH.Domain.Entities;
using BCH.Domain.Primitives;

namespace BCH.Application.Services
{
    public class BlockchainService : IBlockchainService
    {
        private readonly IBlockchainRepository _blockchainRepo;

        public BlockchainService(IBlockchainRepository blockchainRepo)
        {
            _blockchainRepo = blockchainRepo
                ?? throw new ArgumentNullException(nameof(blockchainRepo));
        }

        public async Task<IQueryable<BchInfo>> GetAllBlockchainAsync(CancellationToken cancellationToken)
        {
            return await _blockchainRepo.GetAllAsync(cancellationToken);
        }

        public async Task<IQueryable<BchInfo>> GetBlockchainByTypeAsync(BlockchainType type, CancellationToken cancellationToken)
        {
            return await _blockchainRepo.GetByTypeAsync(type, cancellationToken);
        }

        async Task<BchInfo> IBlockchainService.SaveInfo(BchInfo blockchain, CancellationToken cancellationToken = default)
        {
            return await _blockchainRepo.SaveAsync(blockchain, cancellationToken);
        }
    }
}