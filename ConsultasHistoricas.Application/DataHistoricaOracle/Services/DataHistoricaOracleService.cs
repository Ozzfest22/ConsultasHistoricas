using ConsultasHistoricas.Domain.Models.DataTables;
using ConsultasHistoricas.Domain.Models.Oracle;
using ConsultasHistoricas.Domain.Models.Shared;
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

        public async Task<DataTableResponse<ResultadosPacienteOracle>> GetAllDataTable(DataTableRequest request)
        {
            var req = new ListRequest()
            {
                PageNo = Convert.ToInt32(request.Start / request.Length),
                PageSize = request.Length,
                SortDirection = request.Order[0].Dir,
                NombreBusqueda = request.Search != null ? request.Search.Value.Trim() : "ABC"
            };

            var data = await _repository.GetAllByNameOracleAsync(req);

            if (data == null || !data.Any())
            {
                return new DataTableResponse<ResultadosPacienteOracle>()
                {
                    Draw = request.Draw,
                    RecordsTotal = 0,
                    RecordsFiltered = 0,
                    Data = new ResultadosPacienteOracle[0],
                    Error = ""
                };
            }

            return new DataTableResponse<ResultadosPacienteOracle>()
            {
                Draw = request.Draw,
                RecordsTotal = Convert.ToInt32(data[0].TotalCount),
                RecordsFiltered = data[0].FilteredCount,
                Data = data.ToArray(),
                Error = ""
            };
        }

        public Task<List<ResultadosPacienteOracle>> GetAllOracleAsync(ListRequest request)
        {
            var data = _repository.GetAllByNameOracleAsync(request);

            return data;
        }
    }
}
