using System;
using System.Data;
using Dapper;
using ICMarkets.Core.Entities;
using ICMarkets.Core.Repositories.Query;
using ICMarkets.Infrastructure.Repositories.Query.Base;
using Microsoft.Extensions.Configuration;

namespace ICMarkets.Infrastructure.Repositories.Query
{
    public class DashQueryRepository : QueryRepository<Dash>, IDashQueryRepository
    {
        public DashQueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }

        public async Task<IReadOnlyList<Dash>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM DashCoin";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Dash>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }


        public async Task<Dash> GetByIdAsync(long id)
        {
            try
            {
                var query = "SELECT * FROM DashCoin WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Dash>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

    }

}

