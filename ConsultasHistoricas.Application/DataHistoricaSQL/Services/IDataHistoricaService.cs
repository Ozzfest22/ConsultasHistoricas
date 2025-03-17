using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultasHistoricas.Domain.Models.DataTables;
using ConsultasHistoricas.Domain.Models.SQL;

namespace ConsultasHistoricas.Application.DataHistoricaSQL.Services
{
    public interface IDataHistoricaService
    {
        Task<IEnumerable<ResultadosPacienteSQL>> GetAllAsync();

        Task<List<ResultadosPacienteSQL>> GetAllByNameAsync(ListRequest request);

        Task<DataTableResponse<ResultadosPacienteSQL>> GetAllDataTable(DataTableRequest request);
    }
}
