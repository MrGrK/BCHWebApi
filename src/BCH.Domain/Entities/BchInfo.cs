using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BCH.Domain.Entities
{
    public class BchInfo
    {
        public int Id { get; set; }

        public DateTime CreateAt { get; set; }

        public BCH Bch { get; set; } = null!;
    }

    public class BCH
    {
        public string Name { get; set; }

        public int Height { get; set; }

        public string Hash { get; set; }

        public DateTime CallTime { get; set; }

        public string LatestUrl { get; set; }

        public string PreviousHash { get; set; }

        public string PreviousUrl { get; set; }

        public int PeerCount { get; set; }

        public int UnconfirmedCount { get; set; }

        public int HighFeePerKb { get; set; }

        public int MediumFeePerKb { get; set; }

        public int LowFeePerKb { get; set; }

        public int LastForkHeight { get; set; }

        public string LastForkHash { get; set; }
    }
}
