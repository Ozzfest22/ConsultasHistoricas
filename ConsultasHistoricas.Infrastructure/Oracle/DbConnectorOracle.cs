using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ConsultasHistoricas.Infrastructure.Oracle
{
    public class DbConnectorOracle
    {
        private readonly IConfiguration _configuration;

        public DbConnectorOracle(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            string connectionString = _configuration.GetConnectionString("Oracle")!;

            return new OracleConnection(connectionString);
        }
    }
}
