using System;
using CMarkets.Core.Repositories.Command;
using ICMarkets.Application.Commands;
using ICMarkets.Core.Repositories.Query;
using MediatR;

namespace ICMarkets.Application.Handlers.CommandHandlers
{
	public class DeleteEthHandler : IRequestHandler<DeleteEthCommand, String>
    {
        private readonly IEthCommandRepository _ethCommandRepository;
        private readonly IEthQueryRepository _ethQueryRepository;

        public DeleteEthHandler(IEthCommandRepository ethRepository, IEthQueryRepository ethQueryRepository)
        {
            _ethCommandRepository = ethRepository;
            _ethQueryRepository = ethQueryRepository;
        }


        public async Task<string> Handle(DeleteEthCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ethEntity = await _ethQueryRepository.GetByIdAsync(request.Id);

                await _ethCommandRepository.DeleteAsync(ethEntity);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "Eth information has been deleted!";
        }
    }
}

