using System;
using System.Data;
using Dapper;
using ICMarkets.Core.Entities;
using ICMarkets.Core.Repositories.Query;
using ICMarkets.Infrastructure.Repositories.Query.Base;
using Microsoft.Extensions.Configuration;

namespace ICMarkets.Infrastructure.Repositories.Query
{
    public class BtcQueryRepository : QueryRepository<Btc>, IBtcQueryRepository
    {
        public BtcQueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }

        public async Task<IReadOnlyList<Btc>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM BitCoin";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Btc>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }


        public async Task<Btc> GetByIdAsync(long id)
        {
            try
            {
                var query = "SELECT * FROM BitCoin WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Btc>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

    }

}

