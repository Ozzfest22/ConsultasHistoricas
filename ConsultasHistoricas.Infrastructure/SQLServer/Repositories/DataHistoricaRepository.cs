using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultasHistoricas.Domain.Models.SQL;
using ConsultasHistoricas.Domain.Repositories.Query;
using ConsultasHistoricas.Infrastructure.SQLServer.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ConsultasHistoricas.Infrastructure.SQLServer.Repositories
{
    public class DataHistoricaRepository : QueryRepository<ResultadosPacienteSQL>, IDataHistoricaRepository
    {
        public DataHistoricaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<ResultadosPacienteSQL>> GetAllAsync()
        {
            try
            {
                var storeProcedure = "sp_historicaaa";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<ResultadosPacienteSQL>(
                            storeProcedure,
                            commandType: CommandType.StoredProcedure
                        )).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ResultadosPacienteSQL>> GetAllByNameAsync(ListRequest request)
        {
            try
            {
                var storeProcedure = "spGetHistoricaList";

                using (var connection = CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@NombreBusqueda", request.NombreBusqueda, DbType.String);
                    parameters.Add("@PageNo", request.PageNo, DbType.Int64);
                    parameters.Add("@PageSize", request.PageSize, DbType.Int64);
                    parameters.Add("@SortDirection", request.SortDirection, DbType.String);

                    return (await connection.QueryAsync<ResultadosPacienteSQL>(
                            storeProcedure,
                            parameters,
                            commandType: CommandType.StoredProcedure,
                            commandTimeout: 0
                        )).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
