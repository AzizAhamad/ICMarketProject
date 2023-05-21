using System;
using ICMarkets.Core.Entities;
using MediatR;

namespace ICMarkets.Application.Query
{
	public class GetDashByIdQuery : IRequest<Dash>
    {
        public Int64 Id { get; private set; }

        public GetDashByIdQuery(Int64 Id)
        {
            this.Id = Id;
        }

    }
}


