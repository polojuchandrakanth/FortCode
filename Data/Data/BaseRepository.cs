using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Fort.Data.Data
{
    public class BaseRepository
    {
        private readonly IConfiguration configruation;

        protected BaseRepository(IConfiguration configruation)
        {
            this.configruation = configruation;
        }

        public IDbConnection CreateConnection()
        {
            string connectionstring = configruation.GetConnectionString("BaseConnection");

            if (string.IsNullOrEmpty(connectionstring))
            {
                throw new System.ArgumentException($"'{nameof(connectionstring)}' cannot be null or empty.");
            }

            IDbConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            return connection;
        }

        protected async Task<T> SelectData<T>(string query, DynamicParameters dynamicParameters = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<T>(query, dynamicParameters);
            }
        }

        public async Task<IEnumerable<T>> SelectDataList<T>(string query, DynamicParameters dynamicParameters = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<T>(query, dynamicParameters);
            }
        }

        public async Task<int> AddAsync<T>(T entity)
        {
            using (var connection = CreateConnection())
            {
                return await connection.InsertAsync<int, T>(entity);
            }
        }

        public async Task<int> UpdateAsync<T>(T entity)
        {
            using (var connection = CreateConnection())
            {
                return await connection.UpdateAsync<T>(entity);
            }
        }

        public async Task<int> DeleteAsync<T>(T entity)
        {
            using (var connection = CreateConnection())
            {
                return await connection.DeleteAsync<T>(entity);
            }
        }

        public async Task<int> ExecuteAsync(string query, DynamicParameters dynamicParameters = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.ExecuteAsync(query, dynamicParameters);
            }
        }
        
    }
}
