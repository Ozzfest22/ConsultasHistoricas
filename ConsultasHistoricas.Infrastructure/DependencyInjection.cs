using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultasHistoricas.Domain.Repositories.Query;
using ConsultasHistoricas.Domain.Repositories.Query.Base;
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
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddTransient<IDataHistoricaRepository, DataHistoricaRepository>();
        }
    }
}
