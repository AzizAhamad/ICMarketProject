using System;
using ICMarkets.Core.Entities.Base;
using Newtonsoft.Json;

namespace ICMarkets.Core.Entities

{
	public class Dash:BaseEntity
	{

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("latest_url")]
        public Uri LatestUrl { get; set; }

        [JsonProperty("previous_hash")]
        public string PreviousHash { get; set; }

        [JsonProperty("previous_url")]
        public Uri PreviousUrl { get; set; }

        [JsonProperty("peer_count")]
        public long PeerCount { get; set; }

        [JsonProperty("unconfirmed_count")]
        public long UnconfirmedCount { get; set; }

        [JsonProperty("high_fee_per_kb")]
        public long HighFeePerKb { get; set; }

        [JsonProperty("medium_fee_per_kb")]
        public long MediumFeePerKb { get; set; }

        [JsonProperty("low_fee_per_kb")]
        public long LowFeePerKb { get; set; }

        [JsonProperty("last_fork_height")]
        public long LastForkHeight { get; set; }

        [JsonProperty("last_fork_hash")]
        public string LastForkHash { get; set; }
    }
}

