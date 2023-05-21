using System;
using ICMarkets.Core.Entities;
using ICMarkets.Core.Repositories.Query.Base;

namespace ICMarkets.Core.Repositories.Query
{
	public interface IDashQueryRepository:IQueryRepository<Dash>
    {
        //Custom operation which is not generic
        Task<IReadOnlyList<Dash>> GetAllAsync();
        Task<Dash> GetByIdAsync(Int64 id);
    }
}

