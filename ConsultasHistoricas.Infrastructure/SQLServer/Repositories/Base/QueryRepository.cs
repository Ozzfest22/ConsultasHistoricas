using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultasHistoricas.Domain.Repositories.Query.Base;
using Microsoft.Extensions.Configuration;

namespace ConsultasHistoricas.Infrastructure.SQLServer.Repositories.Base
{
    public class QueryRepository<T> : DbConnectorSQLServer, IQueryRepository<T> where T : class
    {
        protected QueryRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
