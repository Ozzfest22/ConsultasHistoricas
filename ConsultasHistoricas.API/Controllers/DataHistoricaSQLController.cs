using ConsultasHistoricas.Application.DataHistoricaSQL.Services;
using ConsultasHistoricas.Domain.Models.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConsultasHistoricas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DataHistoricaSQLController : ControllerBase
    {
        private readonly IDataHistoricaSQLService _dataHistoricaService;

        public DataHistoricaSQLController(IDataHistoricaSQLService dataHistoricaService)
        {
            _dataHistoricaService = dataHistoricaService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] ListRequest request)
        {
            var data = await _dataHistoricaService.GetAllByNameAsync(request);

            return Ok(data);
        }
    }
}
