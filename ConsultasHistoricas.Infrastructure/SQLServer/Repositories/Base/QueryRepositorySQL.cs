using ConsultasHistoricas.Domain.Repositories.Query.Base;
using Microsoft.Extensions.Configuration;

namespace ConsultasHistoricas.Infrastructure.SQLServer.Repositories.Base
{
    public class QueryRepositorySQL<T> : DbConnectorSQLServer, IQueryRepository<T> where T : class
    {
        protected QueryRepositorySQL(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
