using ConsultasHistoricas.Domain.Models.Oracle;
using ConsultasHistoricas.Domain.Models.Shared;
using ConsultasHistoricas.Domain.Repositories.Query.Base;

namespace ConsultasHistoricas.Domain.Repositories.Query
{
    public interface IDataHistoricaRepositoryOracle : IQueryRepository<ResultadosPacienteOracle>
    {
        Task<List<ResultadosPacienteOracle>> GetAllByNameOracleAsync(ListRequest request);
    }
}
