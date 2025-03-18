using ConsultasHistoricas.Domain.Repositories.Query;
using ConsultasHistoricas.Domain.Repositories.Query.Base;
using ConsultasHistoricas.Infrastructure.Oracle.Repositories;
using ConsultasHistoricas.Infrastructure.Oracle.Repositories.Base;
using ConsultasHistoricas.Infrastructure.SQLServer.Repositories;
using ConsultasHistoricas.Infrastructure.SQLServer.Repositories.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultasHistoricas.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepositorySQL<>));
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepositoryOracle<>));
            services.AddTransient<IDataHistoricaRepositorySQL, DataHistoricaRepositorySQL>();
            services.AddTransient<IDataHistoricaRepositoryOracle, DataHistoricaRepositoryOracle>();
        }
    }
}
