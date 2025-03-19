using Microsoft.AspNetCore.Mvc;

namespace ConsultasHistoricas.Presentation.Controllers
{
    public class DataOracleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OracleView()
        {
            return PartialView("_OraclePartial");
        }
    }
}
