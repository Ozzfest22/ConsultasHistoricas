﻿using ConsultasHistoricas.Application.DataHistoricaSQL.Services;
using ConsultasHistoricas.Domain.Models.DataTables;
using ConsultasHistoricas.Domain.Models.SQL;
using Microsoft.AspNetCore.Mvc;

namespace ConsultasHistoricas.Presentation.Controllers
{
    public class DataSQLController : Controller
    {
        private readonly IDataHistoricaSQLService _dataHistoricaService;

        public DataSQLController(IDataHistoricaSQLService dataHistoricaService)
        {
            _dataHistoricaService = dataHistoricaService;
        }

        public IActionResult Index()
        {
            return View();
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
    }
}
