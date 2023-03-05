using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BCH.Application.Models
{
    public class BCHModel
    {
        /// <summary>
        /// Blockchain name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Blockchain height
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; set; }

        /// <summary>
        /// Blockchain hash
        /// </summary>
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        /// <summary>
        /// Blockchain request time
        /// </summary>
        [JsonPropertyName("time")]
        public DateTime CallTime { get; set; }

        /// <summary>
        /// Blockchain latest url
        /// </summary>
        [JsonPropertyName("latest_url")]
        public string LatestUrl { get; set; }

        /// <summary>
        /// Blockchain previous hash
        /// </summary>
        [JsonPropertyName("previous_hash")]
        public string PreviousHash { get; set; }

        /// <summary>
        /// Blockchain previous url
        /// </summary>
        [JsonPropertyName("previous_url")]
        public string PreviousUrl { get; set; }

        /// <summary>
        /// Blockchain peer count
        /// </summary>
        [JsonPropertyName("peer_count")]
        public int PeerCount { get; set; }

        /// <summary>
        /// Blockchain unconfirmed count
        /// </summary>
        [JsonPropertyName("unconfirmed_count")]
        public int UnconfirmedCount { get; set; }

        /// <summary>
        /// Blockchain high fee per kb
        /// </summary>
        [JsonPropertyName("high_fee_per_kb")]
        public int HighFeePerKb { get; set; }

        /// <summary>
        /// Blockchain medium fee per kb
        /// </summary>
        [JsonPropertyName("medium_fee_per_kb")]
        public int MediumFeePerKb { get; set; }


        /// <summary>
        /// Blockchain low fee per kb
        /// </summary>
        [JsonPropertyName("low_fee_per_kb")]
        public int LowFeePerKb { get; set; }


        /// <summary>
        /// Blockchain last fork height
        /// </summary>
        [JsonPropertyName("last_fork_height")]
        public int LastForkHeight { get; set; }


        /// <summary>
        /// Blockchain last fork hash
        /// </summary>
        [JsonPropertyName("last_fork_hash")]
        public string LastForkHash { get; set; }
    }
}
