using System;
using CMarkets.Core.Repositories.Command;
using ICMarkets.Application.Commands;
using ICMarkets.Application.Mapper;
using ICMarkets.Application.Response;
using ICMarkets.Core.Entities;
using ICMarkets.Core.Repositories.Command;
using ICMarkets.Core.Repositories.Query;
using MediatR;

namespace ICMarkets.Application.Handlers.CommandHandlers
{
	public class EditDashHandler : IRequestHandler<EditDashCommand, DashResponse>
    {
        private readonly IDashCommandRepository _dashCommandRepository;
        private readonly IDashQueryRepository _dashQueryRepository;

        public EditDashHandler(IDashCommandRepository dashRepository, IDashQueryRepository dashQueryRepository)
		{
            _dashCommandRepository = dashRepository;
            _dashQueryRepository = dashQueryRepository;
        }

        public async Task<DashResponse> Handle(EditDashCommand request, CancellationToken cancellationToken)
        {
            var dashEntity = ICMarketsMapper.Mapper.Map<Dash>(request);

            if (dashEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _dashCommandRepository.UpdateAsync(dashEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedDash = await _dashQueryRepository.GetByIdAsync(request.Id);
            var dashResponse = ICMarketsMapper.Mapper.Map<DashResponse>(modifiedDash);

            return dashResponse;
        }
    }
}

