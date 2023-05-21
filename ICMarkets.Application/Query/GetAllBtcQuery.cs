using System;
using ICMarkets.Core.Entities;
using MediatR;

namespace ICMarkets.Application.Query
{
	public class GetAllBtcQuery : IRequest<List<Btc>>
    {
		
	}
}

