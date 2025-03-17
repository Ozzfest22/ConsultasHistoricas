using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ConsultasHistoricas.Domain.Models.SQL;
using ConsultasHistoricas.Domain.Repositories.Query.Base;

namespace ConsultasHistoricas.Domain.Repositories.Query
{
    public interface IDataHistoricaRepository : IQueryRepository<ResultadosPacienteSQL>
    {
        Task<IEnumerable<ResultadosPacienteSQL>> GetAllAsync();

        Task<List<ResultadosPacienteSQL>> GetAllByNameAsync(ListRequest request);
    }
}
