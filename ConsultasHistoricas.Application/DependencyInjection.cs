using ConsultasHistoricas.Application.DataHistoricaOracle.Services;
using ConsultasHistoricas.Application.DataHistoricaSQL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultasHistoricas.Application
{
    public static class DependencyInjection
    {
        public static void RegisterApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDataHistoricaSQLService, DataHistoricaSQLService>();
            services.AddScoped<IDataHistoricaOracleService, DataHistoricaOracleService>();
        }
    }
}
