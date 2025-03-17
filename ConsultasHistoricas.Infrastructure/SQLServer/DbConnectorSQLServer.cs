using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ConsultasHistoricas.Infrastructure.SQLServer
{
    public class DbConnectorSQLServer
    {
        private readonly IConfiguration _configuration;

        public DbConnectorSQLServer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection() 
        {
            string _connectionString = _configuration.GetConnectionString("SqlServer")!;
            return new SqlConnection(_connectionString);
        }
    }
}
