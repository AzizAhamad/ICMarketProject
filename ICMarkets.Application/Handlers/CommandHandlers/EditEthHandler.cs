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
	public class EditEthHandler : IRequestHandler<EditEthCommand, EthResponse>
    {
        private readonly IEthCommandRepository _ethCommandRepository;
        private readonly IEthQueryRepository _ethQueryRepository;

        public EditEthHandler(IEthCommandRepository ethRepository, IEthQueryRepository ethQueryRepository)
		{
            _ethCommandRepository = ethRepository;
            _ethQueryRepository = ethQueryRepository;
        }

        public async Task<EthResponse> Handle(EditEthCommand request, CancellationToken cancellationToken)
        {
            var ethEntity = ICMarketsMapper.Mapper.Map<Eth>(request);

            if (ethEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _ethCommandRepository.UpdateAsync(ethEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedEth = await _ethQueryRepository.GetByIdAsync(request.Id);
            var ethResponse = ICMarketsMapper.Mapper.Map<EthResponse>(modifiedEth);

            return ethResponse;
        }
    }
}

