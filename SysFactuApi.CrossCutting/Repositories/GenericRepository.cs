using Dapper;
using SysFactuApi.CrossCutting.Extensions;
using System.Data;
using System.Data.SqlClient;

namespace SysFactuApi.CrossCutting.Repositories
{
    public class GenericRepository
    {
        private IDbConnection Connection(string dbConnection)
        {
            return new SqlConnection(dbConnection);
        }

        public async Task<IEnumerable<XOutput>> GetAsync<TInput, XOutput>(string dbConnection, string Name, TInput filter, CommandType command) where TInput : class
        {
            using (IDbConnection conn = Connection(dbConnection))
            {
                conn.Open();
                var parameters = filter.GetParameters();
                var result = await conn.QueryAsync<XOutput>(Name, parameters, commandType: command);
                return result;
            }
        }
        public async Task<XOutput> GetAsyncFirst<TInput, XOutput>(string dbConnection, string Name, TInput filter, CommandType command) where TInput : class
        {
            using (IDbConnection conn = Connection(dbConnection))
            {
                conn.Open();
                var parameters = filter.GetParameters();
                var result = await conn.QueryFirstOrDefaultAsync<XOutput>(Name, parameters, commandType: command);
                return result;
            }
        }

        public async Task<IEnumerable<XOutput>> GetAsyncFirstDynamic<XOutput>(string dbConnection, string Name, object filter, CommandType command)
        {
            try
            {
                using (IDbConnection conn = Connection(dbConnection))
                {
                    conn.Open();
                    var parameters = filter;
                    var result = await conn.QueryAsync<XOutput>(Name, parameters, commandType: command);
                    return result;
                }
            }
            catch (System.Exception ex)
            {
                using (IDbConnection conn = Connection(dbConnection))
                {
                    conn.Open();
                    var parameters = filter;
                    var result = await conn.QueryAsync<XOutput>(Name, parameters, commandType: command);
                    return result;
                }
            }
        }
    }

}
