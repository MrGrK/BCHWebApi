using BCH.Domain.Primitives;
using BCH.Domain.ValueObjects;

namespace BCH.Domain.Entities
{
    public class BchInfo
    {
        public int Id { get; set; }

        public DateTime CreateAt { get; set; }

        public BlockchainType Type { get; set; }

        public Info Info { get; set; }
    }



 
}
