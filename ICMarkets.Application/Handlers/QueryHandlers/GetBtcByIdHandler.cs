using System;
using ICMarkets.Application.Query;
using ICMarkets.Core.Entities;
using MediatR;

namespace ICMarkets.Application.Handlers.QueryHandlers
{
    public class GetBtcByIdHandler : IRequestHandler<GetBtcByIdQuery, Btc>
    {
        private readonly IMediator _mediator;

        public GetBtcByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Btc> Handle(GetBtcByIdQuery request, CancellationToken cancellationToken)
        {
            var btc = await _mediator.Send(new GetAllBtcQuery());
            var selectedBtc = btc.FirstOrDefault(x => x.Id == request.Id);
            return selectedBtc;
        }
    }
}

