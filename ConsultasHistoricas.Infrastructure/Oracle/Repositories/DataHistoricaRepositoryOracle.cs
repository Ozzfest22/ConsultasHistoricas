using System.Data;
using ConsultasHistoricas.Domain.Models.Oracle;
using ConsultasHistoricas.Domain.Repositories.Query;
using ConsultasHistoricas.Infrastructure.Oracle.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace ConsultasHistoricas.Infrastructure.Oracle.Repositories
{
    public class DataHistoricaRepositoryOracle : QueryRepositoryOracle<ResultadosPacienteOracle>, IDataHistoricaRepositoryOracle
    {
        public DataHistoricaRepositoryOracle(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<ResultadosPacienteOracle>> GetAllByNameOracleAsync()
        {
            try
            {
                var storeProcedure = "SIGESER.data_test";

                using (var connection = CreateConnection())
                {
                    connection.Open();

                    using (var command = new OracleCommand(storeProcedure, (OracleConnection)connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        var cursorParam = new OracleParameter("p_cursor", OracleDbType.RefCursor)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(cursorParam);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            var data = new List<ResultadosPacienteOracle>();

                            while (await reader.ReadAsync())
                            {
                                data.Add(new ResultadosPacienteOracle 
                                {
                                    YearOrden = reader.GetString(0),
                                    NomPac = reader.GetString(1),
                                    Resultado = reader.GetString(2)
                                });
                            }

                            return data;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
