using System;
using ICMarkets.Application.Response;
using MediatR;

namespace ICMarkets.Application.Commands
{
	public class CreateEthCommand : IRequest<EthResponse>
    {
		public CreateEthCommand()
		{
            this.CreatedAt = DateTime.Now;
		}

        public string Name { get; set; }

        public long Height { get; set; }

        public string Hash { get; set; }

        public DateTimeOffset Time { get; set; }

        public Uri LatestUrl { get; set; }

        public string PreviousHash { get; set; }

        public Uri PreviousUrl { get; set; }

        public long PeerCount { get; set; }

        public long UnconfirmedCount { get; set; }

        public long HighGasPrice { get; set; }

        public long MediumGasPrice { get; set; }

        public long LowGasPrice { get; set; }

        public long HighPriorityFee { get; set; }

        public long MediumPriorityFee { get; set; }

        public long LowPriorityFee { get; set; }

        public long BaseFee { get; set; }

        public long LastForkHeight { get; set; }

        public string LastForkHash { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}

