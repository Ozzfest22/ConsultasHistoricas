using ConsultasHistoricas.Domain.Models.Oracle;
using ConsultasHistoricas.Domain.Repositories.Query;

namespace ConsultasHistoricas.Application.DataHistoricaOracle.Services
{
    public class DataHistoricaOracleService : IDataHistoricaOracleService
    {
        private readonly IDataHistoricaRepositoryOracle _repository;

        public DataHistoricaOracleService(IDataHistoricaRepositoryOracle repository)
        {
            _repository = repository;
        }

        public Task<List<ResultadosPacienteOracle>> GetAllOracleAsync()
        {
            var data = _repository.GetAllByNameOracleAsync();

            return data;
        }
    }
}
