using System;
using ICMarkets.Application.Response;
using MediatR;

namespace ICMarkets.Application.Commands
{
	public class EditBtcCommand: IRequest<BtcResponse>
    {

        public Int64 Id { get; set; }

        public string Name { get; set; }

        public long Height { get; set; }

        public string Hash { get; set; }

        public DateTimeOffset Time { get; set; }

        public Uri LatestUrl { get; set; }

        public string PreviousHash { get; set; }

        public Uri PreviousUrl { get; set; }

        public long PeerCount { get; set; }

        public long UnconfirmedCount { get; set; }

        public long HighFeePerKb { get; set; }

        public long MediumFeePerKb { get; set; }

        public long LowFeePerKb { get; set; }

        public long LastForkHeight { get; set; }

        public string LastForkHash { get; set; }

    }
}

