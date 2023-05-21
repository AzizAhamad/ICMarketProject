using System;
using MediatR;

namespace ICMarkets.Application.Commands
{
	public class DeleteBtcCommand : IRequest<String>
    {
        public Int64 Id { get; private set; }

        public DeleteBtcCommand(Int64 Id)
        {
            this.Id = Id;
        }
	}
}

