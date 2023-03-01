using BCH.Domain.Primitives;


namespace BCH.Domain.Entities
{
    public class Blockchain: Entity
    {
        public BlockchainType Type { get; set; }
    }
}