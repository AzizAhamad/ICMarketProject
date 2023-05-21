using System;
using CMarkets.Core.Repositories.Command;
using ICMarkets.Application.Commands;
using ICMarkets.Application.Mapper;
using ICMarkets.Application.Response;
using ICMarkets.Core.Entities;
using MediatR;

namespace ICMarkets.Application.Handlers.CommandHandlers
{
	public class CreateEthHandler : IRequestHandler<CreateEthCommand, EthResponse>
    {
        private readonly IEthCommandRepository _ethCommandRepository;

        public CreateEthHandler(IEthCommandRepository ethCommandRepository)
        {
            _ethCommandRepository = ethCommandRepository;
        }

        public async Task<EthResponse> Handle(CreateEthCommand request, CancellationToken cancellationToken)
        {
            var ethEntity = ICMarketsMapper.Mapper.Map<Eth>(request);

            if (ethEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newEth = await _ethCommandRepository.AddAsync(ethEntity);
            var ethResponse = ICMarketsMapper.Mapper.Map<EthResponse>(newEth);
            return ethResponse;
        }
    }
}

