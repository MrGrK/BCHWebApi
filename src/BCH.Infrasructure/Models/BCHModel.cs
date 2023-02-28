using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BCH.Infrasructure.Models
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
        public int Height { get; set; }//"height":// 1829099,

        /// <summary>
        /// Blockchain hash
        /// </summary>
        [JsonPropertyName("hash")]
        public string Hash { get; set; }//"hash": "00000000000000236e16f471dcad0359b0ff7480f97c3dbb8c5e773ea283dba7",

        /// <summary>
        /// Blockchain request time
        /// </summary>
        [JsonPropertyName("time")]
        public DateTime CallTime { get; set; }//"time": "2023-02-27T13:49:05.953941166Z",

        /// <summary>
        /// Blockchain latest url
        /// </summary>
        [JsonPropertyName("latest_url")]
        public string LatestUrl { get; set; }//"latest_url": "https://api.blockcypher.com/v1/dash/main/blocks/00000000000000236e16f471dcad0359b0ff7480f97c3dbb8c5e773ea283dba7",

        /// <summary>
        /// Blockchain previous hash
        /// </summary>
        [JsonPropertyName("previous_hash")]
        public string PreviousHash { get; set; }//  "previous_hash": "0000000000000026d0fac819bf805585b38cb28d27dcfc3b80b99725329cef7b",

        /// <summary>
        /// Blockchain previous url
        /// </summary>
        [JsonPropertyName("previous_url")]
        public string PreviousUrl { get; set; }//"previous_url": "https://api.blockcypher.com/v1/dash/main/blocks/0000000000000026d0fac819bf805585b38cb28d27dcfc3b80b99725329cef7b",

        /// <summary>
        /// Blockchain peer count
        /// </summary>
        [JsonPropertyName("peer_count")]
        public int PeerCount { get; set; }//  "peer_count": 165,

        /// <summary>
        /// Blockchain unconfirmed count
        /// </summary>
        [JsonPropertyName("unconfirmed_count")]
        public int UnconfirmedCount { get; set; }//   "unconfirmed_count": 29,

        /// <summary>
        /// Blockchain high fee per kb
        /// </summary>
        [JsonPropertyName("high_fee_per_kb")]
        public int HighFeePerKb { get; set; }//  "high_fee_per_kb": 25491,

        /// <summary>
        /// Blockchain medium fee per kb
        /// </summary>
        [JsonPropertyName("medium_fee_per_kb")]
        public int MediumFeePerKb { get; set; }//"medium_fee_per_kb": 17773,


        /// <summary>
        /// Blockchain low fee per kb
        /// </summary>
        [JsonPropertyName("low_fee_per_kb")]
        public int LowFeePerKb { get; set; }//"low_fee_per_kb": 10526,


        /// <summary>
        /// Blockchain last fork height
        /// </summary>
        [JsonPropertyName("last_fork_height")]
        public int LastForkHeight { get; set; }//  "last_fork_height": 1819039,


        /// <summary>
        /// Blockchain last fork hash
        /// </summary>
        [JsonPropertyName("last_fork_hash")]
        public string LastForkHash { get; set; }//"last_fork_hash": "0000000000000021abb7c6bd902079cd1b7541ee54acc2e9fc265a5f7168b427"    }
    }
}
