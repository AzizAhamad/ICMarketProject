using System;
using ICMarkets.Core.Entities;
using MediatR;

namespace ICMarkets.Application.Query
{
	public class GetBtcByIdQuery : IRequest<Btc>
    {
        public Int64 Id { get; private set; }

        public GetBtcByIdQuery(Int64 Id)
        {
            this.Id = Id;
        }

    }
}


