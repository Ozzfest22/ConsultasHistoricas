using ConsultasHistoricas.Domain.Models.Oracle;

namespace ConsultasHistoricas.Application.DataHistoricaOracle.Services
{
    public interface IDataHistoricaOracleService
    {
        Task<List<ResultadosPacienteOracle>> GetAllOracleAsync();
    }
}
