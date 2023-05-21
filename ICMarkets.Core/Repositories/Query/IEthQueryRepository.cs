using System;
using ICMarkets.Core.Entities;
using ICMarkets.Core.Repositories.Query.Base;

namespace ICMarkets.Core.Repositories.Query
{
	public interface IEthQueryRepository : IQueryRepository<Eth>
    {
        //Custom operation which is not generic
        Task<IReadOnlyList<Eth>> GetAllAsync();
        Task<Eth> GetByIdAsync(Int64 id);
    }
}
