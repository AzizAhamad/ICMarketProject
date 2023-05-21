using System;
using ICMarkets.Application.Commands;
using ICMarkets.Application.Mapper;
using ICMarkets.Application.Response;
using ICMarkets.Core.Entities;
using ICMarkets.Core.Repositories.Command;
using MediatR;

namespace ICMarkets.Application.Handlers.CommandHandlers
{
	public class CreateBtcHandler : IRequestHandler<CreateBtcCommand, BtcResponse>
    {
        private readonly IBtcCommandRepository _btcCommandRepository;


        public CreateBtcHandler(IBtcCommandRepository btcCommandRepository)
        {
            _btcCommandRepository = btcCommandRepository;
           
        }

        public async Task<BtcResponse> Handle(CreateBtcCommand request, CancellationToken cancellationToken)
        {
            var btcEntity = ICMarketsMapper.Mapper.Map<Btc>(request);

            if (btcEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newBtc = await _btcCommandRepository.AddAsync(btcEntity);
            var btcResponse = ICMarketsMapper.Mapper.Map<BtcResponse>(newBtc);
            return btcResponse;
        }
    }
}

