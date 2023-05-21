using System;
using MediatR;

namespace ICMarkets.Application.Commands
{
	public class DeleteEthCommand : IRequest<String>
    {
        public Int64 Id { get; private set; }

        public DeleteEthCommand(Int64 Id)
        {
            this.Id = Id;
        }
	}
}

