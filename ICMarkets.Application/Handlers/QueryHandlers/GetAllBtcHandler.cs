using System;
using ICMarkets.Application.Query;
using ICMarkets.Core.Entities;
using ICMarkets.Core.Repositories.Query;
using MediatR;

namespace ICMarkets.Application.Handlers.QueryHandlers
{
	public class GetAllBtcHandler : IRequestHandler<GetAllBtcQuery, List<Btc>>
    {
        private readonly IBtcQueryRepository _btcQueryRepository;
        private readonly HttpClient client;


        public GetAllBtcHandler(IBtcQueryRepository btcQueryRepository,HttpClient client)
        {
            _btcQueryRepository = btcQueryRepository;

            client = new HttpClient()
            {
                BaseAddress = new Uri("https://api.blockcypher.com/v1/btc/main")
            };
        }
        public async Task<List<Btc>> Handle(GetAllBtcQuery request, CancellationToken cancellationToken)
        {
            return (List<Btc>)await _btcQueryRepository.GetAllAsync();
        }
    }
}


