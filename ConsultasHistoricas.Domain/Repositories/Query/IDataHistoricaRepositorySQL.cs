using ConsultasHistoricas.Domain.Models.Shared;
using ConsultasHistoricas.Domain.Models.SQL;
using ConsultasHistoricas.Domain.Repositories.Query.Base;

namespace ConsultasHistoricas.Domain.Repositories.Query
{
    public interface IDataHistoricaRepositorySQL : IQueryRepository<ResultadosPacienteSQL>
    {
        Task<List<ResultadosPacienteSQL>> GetAllByNameSQLAsync(ListRequest request);
    }
}
