using Dapper;
using Easy.WebApi.IDal;
using Easy.WebApi.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Easy.WebApi.Dal
{
    /// <summary>
    /// Dapper
    /// </summary>
    public class DapperDemoDal : IDapperDemoDal
    {
        private readonly IConfiguration _configuration;

        public DapperDemoDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<List<EntityDemo>> GetDemo()
        {
            using (IDbConnection conn = new SqlConnection(_configuration["ConnectionStrings:default"]))
            {
                var query = await conn.QueryFirstOrDefaultAsync<List<EntityDemo>>(@"select * from demo");
                return query;
            }
        }
    }
}