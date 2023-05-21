using System;
using ICMarkets.Core.Entities;
using MediatR;

namespace ICMarkets.Application.Query
{
	public class GetEthByIdQuery : IRequest<Eth>
    {
        public Int64 Id { get; private set; }

        public GetEthByIdQuery(Int64 Id)
        {
            this.Id = Id;
        }

    }
}


