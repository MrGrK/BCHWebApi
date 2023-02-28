using BCH.Domain.Interfaces.Services;
using BCH.Domain;
using BCH.Domain.Interfaces.Repositories;

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

        public async Task<IQueryable<Blockchain>> GetAllBlockchainAsync(CancellationToken cancellationToken)
        {
            return await _blockchainRepo.GetAllAsync(cancellationToken);
        }

        public async Task<IQueryable<Blockchain>> GetBlockchainByTypeAsync(BlockchainType type, CancellationToken cancellationToken)
        {
            return await _blockchainRepo.GetByTypeAsync(type, cancellationToken);
        }

        async Task<bool> IBlockchainService.SaveInfo(Blockchain blockchain, CancellationToken cancellationToken = default)
        {
            return await _blockchainRepo.SaveAsync(blockchain, cancellationToken);
        }
    }
}