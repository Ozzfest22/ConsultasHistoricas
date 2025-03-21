using ConsultasHistoricas.Application.Abstractions;
using ConsultasHistoricas.Application.DataHistoricaOracle.Services;
using ConsultasHistoricas.Domain.Models.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConsultasHistoricas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DataHistoricaOracleController : ControllerBase
    {
        private readonly IDataHistoricaOracleService _dataHistoricaService;
        private readonly IExcelExportService _excelExportService;

        public DataHistoricaOracleController(IDataHistoricaOracleService dataHistoricaService, IExcelExportService excelExportService)
        {
            _dataHistoricaService = dataHistoricaService;
            _excelExportService = excelExportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ListRequest request)
        {
            var data = await _dataHistoricaService.GetAllOracleAsync(request);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> ExcelDownload(string name)
        {
            try
            {
                var content = await _excelExportService.ExportDataOracle(name);

                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Resultados {name.ToUpper()}");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
