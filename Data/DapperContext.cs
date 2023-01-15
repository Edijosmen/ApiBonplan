using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectionSqlServer");
        }

        public IDbConnection CrearConnecion()
        {
            var connection = new SqlConnection(_connectionString);
            return connection;
        }
    }
}