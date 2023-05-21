using System;
using ICMarkets.Application.Query;
using ICMarkets.Core.Entities;
using ICMarkets.Core.Repositories.Query;
using MediatR;

namespace ICMarkets.Application.Handlers.QueryHandlers
{
	public class GetAllEthHandler : IRequestHandler<GetAllEthQuery, List<Eth>>
    {
        private readonly IEthQueryRepository _ethQueryRepository;
        private readonly HttpClient client;


        public GetAllEthHandler(IEthQueryRepository ethQueryRepository,HttpClient client)
        {
            _ethQueryRepository = ethQueryRepository;
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://api.blockcypher.com/v1/eth/main")
            };
        }
        public async Task<List<Eth>> Handle(GetAllEthQuery request, CancellationToken cancellationToken)
        {
            return (List<Eth>)await _ethQueryRepository.GetAllAsync();
        }
    }
}


