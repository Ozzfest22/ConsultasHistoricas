using System.Data;
using ConsultasHistoricas.Domain.Models.Oracle;
using ConsultasHistoricas.Domain.Models.SQL;
using ConsultasHistoricas.Domain.Repositories.Query;
using ConsultasHistoricas.Infrastructure.Oracle.Repositories.Base;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace ConsultasHistoricas.Infrastructure.Oracle.Repositories
{
    public class DataHistoricaRepositoryOracle : QueryRepositoryOracle<ResultadosPacienteOracle>, IDataHistoricaRepositoryOracle
    {
        public DataHistoricaRepositoryOracle(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<ResultadosPacienteOracle>> GetAllByNameOracleAsync(ListRequest request)
        {
            try
            {
                var storeProcedure = "SIGESER.spGetHistoricaListOracle";

                using (var connection = CreateConnection())
                {
                    connection.Open();

                    using (var command = new OracleCommand(storeProcedure, (OracleConnection)connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        var nombreBusqueda = new OracleParameter("p_NombreBusqueda", OracleDbType.Varchar2)
                        {
                            Direction = ParameterDirection.Input
                        };

                        var pageNo = new OracleParameter("p_PageNo", OracleDbType.Int64)
                        {
                            Direction = ParameterDirection.Input
                        };

                        var pageSize = new OracleParameter("p_PageSize", OracleDbType.Int64)
                        {
                            Direction = ParameterDirection.Input
                        };

                        var sortDirection = new OracleParameter("p_SortDirection", OracleDbType.Varchar2)
                        {
                            Direction = ParameterDirection.Input
                        };

                        var cursorParam = new OracleParameter("p_Resultado", OracleDbType.RefCursor)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(nombreBusqueda).Value = request.NombreBusqueda;
                        command.Parameters.Add(pageNo).Value = request.PageNo;
                        command.Parameters.Add(pageSize).Value = request.PageSize;
                        command.Parameters.Add(sortDirection).Value = request.SortDirection;
                        command.Parameters.Add(cursorParam);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            var data = new List<ResultadosPacienteOracle>();

                            while (await reader.ReadAsync())
                            {
                                data.Add(new ResultadosPacienteOracle 
                                {
                                    Row_Num = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                    OrdenAño = reader.IsDBNull(1) ? null : reader.GetString(1),
                                    NroOrden = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    CabeceraOrdServicio = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    Paciente = reader.IsDBNull(4) ? null : reader.GetString(4),
                                    Edad = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                                    Medico = reader.IsDBNull(6) ? null : reader.GetString(6),
                                    FechaOrden = reader.GetDateTime(7),
                                    CodigoHistoria = reader.IsDBNull(8) ? null : reader.GetString(8),
                                    Resultado = reader.IsDBNull(9) ? null : reader.GetString(9),
                                    Examen = reader.IsDBNull(10) ? null : reader.GetString(10),
                                    Metodo = reader.IsDBNull(11) ? null : reader.GetString(11),
                                    Unidad = reader.IsDBNull(12) ? null : reader.GetString(12),
                                    ValorReferencial = reader.IsDBNull(13) ? null : reader.GetString(13),
                                    Seccion = reader.IsDBNull(14) ? null : reader.GetString(14),
                                    Perfil = reader.IsDBNull(15) ? null : reader.GetString(15),
                                    FechaMuestra = reader.IsDBNull(16) ? null : reader.GetDateTime(16),
                                    ResultadoOrigen = reader.IsDBNull(17) ? null : reader.GetString(17),
                                    ResultadoNuevo = reader.IsDBNull(18) ? null : reader.GetString(18),
                                    Servicio = reader.IsDBNull(19) ? null : reader.GetString(19),
                                    FilteredCount = reader.IsDBNull(20) ? 0 : Convert.ToInt32(reader.GetString(20)),
                                    TotalCount = reader.IsDBNull(21) ? null : reader.GetString(21)
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
