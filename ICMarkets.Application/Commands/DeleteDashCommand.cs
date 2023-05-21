using System;
using MediatR;

namespace ICMarkets.Application.Commands
{
	public class DeleteDashCommand : IRequest<String>
    {
        public Int64 Id { get; private set; }

        public DeleteDashCommand(Int64 Id)
        {
            this.Id = Id;
        }
	}
}

