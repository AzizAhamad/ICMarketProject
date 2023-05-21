using System;
using ICMarkets.Application.Query;
using ICMarkets.Core.Entities;
using MediatR;

namespace ICMarkets.Application.Handlers.QueryHandlers
{
    public class GetDashByIdHandler : IRequestHandler<GetDashByIdQuery, Dash>
    {
        private readonly IMediator _mediator;

        public GetDashByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Dash> Handle(GetDashByIdQuery request, CancellationToken cancellationToken)
        {
            var dash = await _mediator.Send(new GetAllDashQuery());
            var selectedDash = dash.FirstOrDefault(x => x.Id == request.Id);
            return selectedDash;
        }
    }
}

