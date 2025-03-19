using ConsultasHistoricas.Application.DataHistoricaOracle.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsultasHistoricas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DataHistoricaOracleController : ControllerBase
    {
        private readonly IDataHistoricaOracleService _dataHistoricaService;

        public DataHistoricaOracleController(IDataHistoricaOracleService dataHistoricaService)
        {
            _dataHistoricaService = dataHistoricaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _dataHistoricaService.GetAllOracleAsync();

            return Ok(data);
        }
    }
}
