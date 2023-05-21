using System;
using CMarkets.Core.Repositories.Command;
using ICMarkets.Application.Commands;
using ICMarkets.Core.Repositories.Command;
using ICMarkets.Core.Repositories.Query;
using MediatR;

namespace ICMarkets.Application.Handlers.CommandHandlers
{
	public class DeleteBtcHandler : IRequestHandler<DeleteBtcCommand, String>
    {
        private readonly IBtcCommandRepository _btcCommandRepository;
        private readonly IBtcQueryRepository _btcQueryRepository;

        public DeleteBtcHandler(IBtcCommandRepository btcRepository, IBtcQueryRepository btcQueryRepository)
        {
            _btcCommandRepository = btcRepository;
            _btcQueryRepository = btcQueryRepository;
        }


        public async Task<string> Handle(DeleteBtcCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var btcEntity = await _btcQueryRepository.GetByIdAsync(request.Id);

                await _btcCommandRepository.DeleteAsync(btcEntity);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "Dash information has been deleted!";
        }
    }
}

