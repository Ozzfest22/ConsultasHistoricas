using ConsultasHistoricas.Domain.Models.DataTables;
using ConsultasHistoricas.Domain.Models.Oracle;
using ConsultasHistoricas.Domain.Models.Shared;

namespace ConsultasHistoricas.Application.DataHistoricaOracle.Services
{
    public interface IDataHistoricaOracleService
    {
        Task<List<ResultadosPacienteOracle>> GetAllOracleAsync(ListRequest request);

        Task<DataTableResponse<ResultadosPacienteOracle>> GetAllDataTable(DataTableRequest request);
    }
}
