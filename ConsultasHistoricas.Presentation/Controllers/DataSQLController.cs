using ConsultasHistoricas.Application.Abstractions;
using ConsultasHistoricas.Application.DataHistoricaSQL.Services;
using ConsultasHistoricas.Domain.Models.DataTables;
using ConsultasHistoricas.Domain.Models.SQL;
using Microsoft.AspNetCore.Mvc;

namespace ConsultasHistoricas.Presentation.Controllers
{
    public class DataSQLController : Controller
    {
        private readonly IDataHistoricaSQLService _dataHistoricaService;
        private readonly IExcelExportService _excelExportService;

        public DataSQLController(IDataHistoricaSQLService dataHistoricaService, IExcelExportService excelExportService)
        {
            _dataHistoricaService = dataHistoricaService;
            _excelExportService = excelExportService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SQLView()
        {
            return PartialView("_SqlPartial");
        }

        [HttpPost]
        public async Task<DataTableResponse<ResultadosPacienteSQL>> GetData()
        {
            try
            {
                var request = new DataTableRequest();

                request.Draw = Convert.ToInt32(Request.Form["draw"].FirstOrDefault() ?? "0");
                request.Start = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
                request.Length = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
                request.Search = new DataTableSearch()
                {
                    Value = Request.Form["search[value]"].FirstOrDefault() ?? "ABC"
                };
                request.Order = new DataTableOrder[]
                {
                    new DataTableOrder()
                    {
                        Dir = Request.Form["order[0][dir]"].FirstOrDefault()
                    }
                };

                return await _dataHistoricaService.GetAllDataTable(request);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> ExcelDownload(string name) 
        {
            try
            {
                var content = await _excelExportService.ExportDataSQL(name);

                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Resultados {name.ToUpper()}");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
