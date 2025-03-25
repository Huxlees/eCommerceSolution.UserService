

using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string? conn = _configuration.GetConnectionString("PostgresConnection");
            _connection= new NpgsqlConnection(conn);
        }
        public IDbConnection dbConnection => _connection;
        //public IDbConnection dbConnection { get { return _connection; } }
    }
}
