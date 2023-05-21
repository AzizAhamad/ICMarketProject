using System;
using ICMarkets.Application.Query;
using ICMarkets.Core.Entities;
using MediatR;

namespace ICMarkets.Application.Handlers.QueryHandlers
{
    public class GetEthByIdHandler : IRequestHandler<GetEthByIdQuery, Eth>
    {
        private readonly IMediator _mediator;

        public GetEthByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Eth> Handle(GetEthByIdQuery request, CancellationToken cancellationToken)
        {
            var eth = await _mediator.Send(new GetAllEthQuery());
            var selectedEth = eth.FirstOrDefault(x => x.Id == request.Id);
            return selectedEth;
        }
    }
}

