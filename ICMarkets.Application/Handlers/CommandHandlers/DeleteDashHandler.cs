using System;
using CMarkets.Core.Repositories.Command;
using ICMarkets.Application.Commands;
using ICMarkets.Core.Repositories.Query;
using MediatR;

namespace ICMarkets.Application.Handlers.CommandHandlers
{
	public class DeleteDashHandler : IRequestHandler<DeleteDashCommand, String>
    {
        private readonly IDashCommandRepository _dashCommandRepository;
        private readonly IDashQueryRepository _dashQueryRepository;

        public DeleteDashHandler(IDashCommandRepository dashRepository, IDashQueryRepository dashQueryRepository)
        {
            _dashCommandRepository = dashRepository;
            _dashQueryRepository = dashQueryRepository;
        }


        public async Task<string> Handle(DeleteDashCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dashEntity = await _dashQueryRepository.GetByIdAsync(request.Id);

                await _dashCommandRepository.DeleteAsync(dashEntity);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "Dash information has been deleted!";
        }
    }
}

