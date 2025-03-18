﻿using ConsultasHistoricas.Domain.Models.DataTables;
using ConsultasHistoricas.Domain.Models.SQL;
using ConsultasHistoricas.Domain.Repositories.Query;

namespace ConsultasHistoricas.Application.DataHistoricaSQL.Services
{
    public class DataHistoricaService : IDataHistoricaService
    {

        private readonly IDataHistoricaRepositorySQL _repository;

        public DataHistoricaService(IDataHistoricaRepositorySQL repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<ResultadosPacienteSQL>> GetAllAsync()
        {
            var data = _repository.GetAllAsync();

            return data;
        }

        public Task<List<ResultadosPacienteSQL>> GetAllByNameAsync(ListRequest request)
        {
            var data = _repository.GetAllByNameSQLAsync(request);

            return data;
        }

        public async Task<DataTableResponse<ResultadosPacienteSQL>> GetAllDataTable(DataTableRequest request)
        {
            var req = new ListRequest()
            {
                PageNo = Convert.ToInt32(request.Start / request.Length),
                PageSize = request.Length,
                SortDirection = request.Order[0].Dir,
                NombreBusqueda = request.Search != null ? request.Search.Value.Trim() : "ABC"
            };

            var data = await _repository.GetAllByNameSQLAsync(req);
            
            return new DataTableResponse<ResultadosPacienteSQL>()
            {
                Draw = request.Draw,
                RecordsTotal = data[0].TotalCount,
                RecordsFiltered = data[0].FilteredCount,
                Data = data.ToArray(),
                Error = ""
            };
        }
    }
}
