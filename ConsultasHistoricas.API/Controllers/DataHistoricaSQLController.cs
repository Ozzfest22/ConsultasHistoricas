using ConsultasHistoricas.Application.DataHistoricaSQL.Services;
using ConsultasHistoricas.Domain.Models.SQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultasHistoricas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DataHistoricaSQLController : ControllerBase
    {
        private readonly IDataHistoricaService _dataHistoricaService;

        public DataHistoricaSQLController(IDataHistoricaService dataHistoricaService)
        {
            _dataHistoricaService = dataHistoricaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var data = await _dataHistoricaService.GetAllAsync();

            return Ok(data);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetAllByName([FromQuery] ListRequest request) 
        {
            var data = await _dataHistoricaService.GetAllByNameAsync(request);

            return Ok(data);
        }
    }
}
