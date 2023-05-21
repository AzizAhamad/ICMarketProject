using System;
using ICMarkets.Core.Repositories.Query.Base;
using Microsoft.Extensions.Configuration;

namespace ICMarkets.Infrastructure.Repositories.Query.Base
{
    public class QueryRepository<T> : DbConnector, IQueryRepository<T> where T : class
    {
        public QueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }
    }
}

