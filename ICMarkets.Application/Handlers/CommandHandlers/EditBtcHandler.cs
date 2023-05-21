using System;
using ICMarkets.Application.Commands;
using ICMarkets.Application.Mapper;
using ICMarkets.Application.Response;
using ICMarkets.Core.Entities;
using ICMarkets.Core.Repositories.Command;
using ICMarkets.Core.Repositories.Query;
using MediatR;

namespace ICMarkets.Application.Handlers.CommandHandlers
{
	public class EditBtcHandler : IRequestHandler<EditBtcCommand, BtcResponse>
    {
        private readonly IBtcCommandRepository _btcCommandRepository;
        private readonly IBtcQueryRepository _btcQueryRepository;

        public EditBtcHandler(IBtcCommandRepository btcRepository, IBtcQueryRepository btcQueryRepository)
		{
            _btcCommandRepository = btcRepository;
            _btcQueryRepository = btcQueryRepository;
        }

        public async Task<BtcResponse> Handle(EditBtcCommand request, CancellationToken cancellationToken)
        {
            var btcEntity = ICMarketsMapper.Mapper.Map<Btc>(request);

            if (btcEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _btcCommandRepository.UpdateAsync(btcEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedBtc = await _btcQueryRepository.GetByIdAsync(request.Id);
            var btcResponse = ICMarketsMapper.Mapper.Map<BtcResponse>(modifiedBtc);

            return btcResponse;
        }
    }
}

