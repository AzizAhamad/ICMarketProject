using System;
using CMarkets.Core.Repositories.Command;
using ICMarkets.Application.Commands;
using ICMarkets.Application.Mapper;
using ICMarkets.Application.Response;
using ICMarkets.Core.Entities;
using ICMarkets.Core.Repositories.Command;
using MediatR;

namespace ICMarkets.Application.Handlers.CommandHandlers
{
	public class CreateDashHandler : IRequestHandler<CreateDashCommand, DashResponse>
    {
        private readonly IDashCommandRepository _dashCommandRepository;
     


        public CreateDashHandler(IDashCommandRepository dashCommandRepository)
        {
            _dashCommandRepository = dashCommandRepository;
           
        }

        public async Task<DashResponse> Handle(CreateDashCommand request, CancellationToken cancellationToken)
        {
            var dashEntity = ICMarketsMapper.Mapper.Map<Dash>(request);

            if (dashEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newDash = await _dashCommandRepository.AddAsync(dashEntity);
            var dashResponse = ICMarketsMapper.Mapper.Map<DashResponse>(newDash);
            return dashResponse;
        }
    }
}

