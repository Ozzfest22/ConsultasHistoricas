using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultasHistoricas.Application.DataHistoricaSQL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultasHistoricas.Application
{
    public static class DependencyInjection
    {
        public static void RegisterApplication(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<IDataHistoricaService, DataHistoricaService>();
        }
    }
}
