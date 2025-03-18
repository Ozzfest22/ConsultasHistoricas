using ConsultasHistoricas.Domain.Models.Oracle;
using ConsultasHistoricas.Domain.Repositories.Query;
using ConsultasHistoricas.Infrastructure.Oracle.Repositories.Base;
using Microsoft.Extensions.Configuration;

namespace ConsultasHistoricas.Infrastructure.Oracle.Repositories
{
    public class DataHistoricaRepositoryOracle : QueryRepositoryOracle<ResultadosPacienteOracle>, IDataHistoricaRepositoryOracle
    {
        public DataHistoricaRepositoryOracle(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<List<ResultadosPacienteOracle>> GetAllByNameOracleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
