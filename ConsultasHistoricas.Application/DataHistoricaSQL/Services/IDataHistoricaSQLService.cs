using ConsultasHistoricas.Domain.Models.DataTables;
using ConsultasHistoricas.Domain.Models.Shared;
using ConsultasHistoricas.Domain.Models.SQL;

namespace ConsultasHistoricas.Application.DataHistoricaSQL.Services
{
    public interface IDataHistoricaSQLService
    {
        Task<IEnumerable<ResultadosPacienteSQL>> GetAllAsync();

        Task<List<ResultadosPacienteSQL>> GetAllByNameAsync(ListRequest request);

        Task<DataTableResponse<ResultadosPacienteSQL>> GetAllDataTable(DataTableRequest request);
    }
}
