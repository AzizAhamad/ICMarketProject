using System;
using ICMarkets.Application.Query;
using ICMarkets.Core.Entities;
using ICMarkets.Core.Repositories.Query;
using MediatR;

namespace ICMarkets.Application.Handlers.QueryHandlers
{
	public class GetAllDashHandler : IRequestHandler<GetAllDashQuery, List<Dash>>
    {
        private readonly IDashQueryRepository _dashQueryRepository;
        private static readonly HttpClient client;

        public GetAllDashHandler(IDashQueryRepository dashQueryRepository, HttpClient client)
        {
            _dashQueryRepository = dashQueryRepository;
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://api.blockcypher.com/v1/dash/main")
            };
        }
        public async Task<List<Dash>> Handle(GetAllDashQuery request, CancellationToken cancellationToken)
        {
            return (List<Dash>)await _dashQueryRepository.GetAllAsync();
        }
    }
}


