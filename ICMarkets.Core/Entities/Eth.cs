using System;
using ICMarkets.Core.Entities.Base;
using Newtonsoft.Json;

namespace ICMarkets.Core.Entities
{
	public class Eth:BaseEntity
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

        [JsonProperty("high_gas_price")]
        public long HighGasPrice { get; set; }

        [JsonProperty("medium_gas_price")]
        public long MediumGasPrice { get; set; }

        [JsonProperty("low_gas_price")]
        public long LowGasPrice { get; set; }

        [JsonProperty("high_priority_fee")]
        public long HighPriorityFee { get; set; }

        [JsonProperty("medium_priority_fee")]
        public long MediumPriorityFee { get; set; }

        [JsonProperty("low_priority_fee")]
        public long LowPriorityFee { get; set; }

        [JsonProperty("base_fee")]
        public long BaseFee { get; set; }

        [JsonProperty("last_fork_height")]
        public long LastForkHeight { get; set; }

        [JsonProperty("last_fork_hash")]
        public string LastForkHash { get; set; }
	}
}

