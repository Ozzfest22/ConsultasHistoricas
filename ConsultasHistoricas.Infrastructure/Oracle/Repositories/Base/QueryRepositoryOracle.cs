using ConsultasHistoricas.Domain.Repositories.Query.Base;
using Microsoft.Extensions.Configuration;

namespace ConsultasHistoricas.Infrastructure.Oracle.Repositories.Base
{
    public class QueryRepositoryOracle<T> : DbConnectorOracle, IQueryRepository<T> where T : class
    {
        public QueryRepositoryOracle(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
