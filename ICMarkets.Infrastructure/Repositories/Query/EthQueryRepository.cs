using System;
using System.Data;
using Dapper;
using ICMarkets.Core.Entities;
using ICMarkets.Core.Repositories.Query;
using ICMarkets.Infrastructure.Repositories.Query.Base;
using Microsoft.Extensions.Configuration;

namespace ICMarkets.Infrastructure.Repositories.Query
{
    public class EthQueryRepository : QueryRepository<Eth>, IEthQueryRepository
    {
        public EthQueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }

        public async Task<IReadOnlyList<Eth>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM EtheriumCoin";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Eth>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Eth> GetByIdAsync(long id)
        {
            try
            {
                var query = "SELECT * FROM EtheriumCoin WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Eth>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

    }

}

