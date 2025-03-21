using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using ConsultasHistoricas.Application.Abstractions;
using ConsultasHistoricas.Domain.Models.Shared;
using ConsultasHistoricas.Domain.Repositories.Query;

namespace ConsultasHistoricas.Infrastructure.Externals.FileExports
{
    public class ExcelExportService : IExcelExportService
    {
        private readonly IDataHistoricaRepositorySQL _dataHistoricaRepositorySQL;
        private readonly IDataHistoricaRepositoryOracle _dataHistoricaRepositoryOracle;

        public ExcelExportService(
            IDataHistoricaRepositorySQL dataHistoricaRepositorySQL, 
            IDataHistoricaRepositoryOracle dataHistoricaRepositoryOracle)
        {
            _dataHistoricaRepositorySQL = dataHistoricaRepositorySQL;
            _dataHistoricaRepositoryOracle = dataHistoricaRepositoryOracle;
        }

        public async Task<byte[]> ExportDataOracle(string name)
        {
            var request = new ListRequest()
            {
                NombreBusqueda = name,
                PageNo = 0,
                PageSize = 1000,
                SortDirection = "ASC"
            };

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Datos");
                var currentRow = 1;

                worksheet.Cell(currentRow, 1).Value = "OrdenAño";
                worksheet.Cell(currentRow, 2).Value = "NroOrden";
                worksheet.Cell(currentRow, 3).Value = "CabeceraOrdServicio";
                worksheet.Cell(currentRow, 4).Value = "Paciente";
                worksheet.Cell(currentRow, 5).Value = "Edad";
                worksheet.Cell(currentRow, 6).Value = "Medico";
                worksheet.Cell(currentRow, 7).Value = "FechaOrden";
                worksheet.Cell(currentRow, 8).Value = "CodigoHistoria";
                worksheet.Cell(currentRow, 9).Value = "Resultado";
                worksheet.Cell(currentRow, 10).Value = "Examen";
                worksheet.Cell(currentRow, 11).Value = "Metodo";
                worksheet.Cell(currentRow, 12).Value = "Unidad";
                worksheet.Cell(currentRow, 13).Value = "ValorReferencial";
                worksheet.Cell(currentRow, 14).Value = "Seccion";
                worksheet.Cell(currentRow, 15).Value = "Perfil";
                worksheet.Cell(currentRow, 16).Value = "FechaMuestra";
                worksheet.Cell(currentRow, 17).Value = "ResultadoOrigen";
                worksheet.Cell(currentRow, 18).Value = "ResultadoNuevo";
                worksheet.Cell(currentRow, 19).Value = "Servicio";

                var data = await _dataHistoricaRepositoryOracle.GetAllByNameOracleAsync(request);

                foreach (var item in data)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.OrdenAño;
                    worksheet.Cell(currentRow, 2).Value = item.NroOrden;
                    worksheet.Cell(currentRow, 3).Value = item.CabeceraOrdServicio;
                    worksheet.Cell(currentRow, 4).Value = item.Paciente;
                    worksheet.Cell(currentRow, 5).Value = item.Edad;
                    worksheet.Cell(currentRow, 6).Value = item.Medico;
                    worksheet.Cell(currentRow, 7).Value = item.FechaOrden;
                    worksheet.Cell(currentRow, 8).Value = item.CodigoHistoria;
                    worksheet.Cell(currentRow, 9).Value = item.Resultado;
                    worksheet.Cell(currentRow, 10).Value = item.Examen;
                    worksheet.Cell(currentRow, 11).Value = item.Metodo;
                    worksheet.Cell(currentRow, 12).Value = item.Unidad;
                    worksheet.Cell(currentRow, 13).Value = item.ValorReferencial;
                    worksheet.Cell(currentRow, 14).Value = item.Seccion;
                    worksheet.Cell(currentRow, 15).Value = item.Perfil;
                    worksheet.Cell(currentRow, 16).Value = item.FechaMuestra;
                    worksheet.Cell(currentRow, 17).Value = item.ResultadoOrigen;
                    worksheet.Cell(currentRow, 18).Value = item.ResultadoNuevo;
                    worksheet.Cell(currentRow, 19).Value = item.Servicio;
                }

                worksheet.Columns().AdjustToContents();
                var range = worksheet.RangeUsed();
                range.CreateTable();


                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }
        }

        public async Task<byte[]> ExportDataSQL(string name)
        {
            var request = new ListRequest() 
            {
                NombreBusqueda = name,
                PageNo = 0,
                PageSize = 1000,
                SortDirection = "ASC"
            };


            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Datos");
                var currentRow = 1;

                worksheet.Cell(currentRow, 1).Value = "CodigoHistoria";
                worksheet.Cell(currentRow, 2).Value = "Nombre";
                worksheet.Cell(currentRow, 3).Value = "OrdenAño";
                worksheet.Cell(currentRow, 4).Value = "OrdenNumero";
                worksheet.Cell(currentRow, 5).Value = "OrdenFecha";
                worksheet.Cell(currentRow, 6).Value = "NombreExamen";
                worksheet.Cell(currentRow, 7).Value = "FechaIngreso";
                worksheet.Cell(currentRow, 8).Value = "Resultado";
                worksheet.Cell(currentRow, 9).Value = "FechaResultado";
                worksheet.Cell(currentRow, 10).Value = "UltimoResultado";
                worksheet.Cell(currentRow, 11).Value = "FechaUltResultado";
                worksheet.Cell(currentRow, 12).Value = "UltimoResultado2";
                worksheet.Cell(currentRow, 13).Value = "FechaUltResultado2";

                var data = await _dataHistoricaRepositorySQL.GetAllByNameSQLAsync(request);

                foreach (var item in data) 
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.CodigoHistoria;
                    worksheet.Cell(currentRow, 2).Value = item.Nombre;
                    worksheet.Cell(currentRow, 3).Value = item.OrdenAño;
                    worksheet.Cell(currentRow, 4).Value = item.OrdenNumero;
                    worksheet.Cell(currentRow, 5).Value = item.OrdenFecha;
                    worksheet.Cell(currentRow, 6).Value = item.NombreExamen;
                    worksheet.Cell(currentRow, 7).Value = item.FechaIngreso;
                    worksheet.Cell(currentRow, 8).Value = item.Resultado;
                    worksheet.Cell(currentRow, 9).Value = item.FechaResultado;
                    worksheet.Cell(currentRow, 10).Value = item.UltimoResultado;
                    worksheet.Cell(currentRow, 11).Value = item.FechaUltResultado;
                    worksheet.Cell(currentRow, 12).Value = item.UltimoResultado2;
                    worksheet.Cell(currentRow, 13).Value = item.FechaUltResultado2;
                }

                worksheet.Columns().AdjustToContents();
                var range = worksheet.RangeUsed();
                range.CreateTable();
                

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }
        }
    }
}
