using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calculadora.Models;
using Calculadora.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calculadora.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApiController : ControllerBase
    {
        private readonly IEnumerable<ICalculatorService> _calculatorServices;
        private static List<HistoricoViewModel> historico = new List<HistoricoViewModel>(0);

        private readonly ILogger<ApiController> _logger;

        public ApiController(
            ILogger<ApiController> logger,
            IEnumerable<ICalculatorService> calculatorServices
        )
        {
            _calculatorServices = calculatorServices;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<HistoricoViewModel> Get() => historico;

        [HttpPost]
        public ActionResult Calcular([FromBody] RequestViewModel request)
        {
            var service = _calculatorServices.FirstOrDefault(c => c.CodigoOperacao == request.Operacao) ?? throw new ArgumentException("Service not found");

            var response = service.Execute(request);

            historico.Add(new HistoricoViewModel(request, response));

            return Ok(response);
        }

        [HttpGet]
        public IActionResult Download() 
        {
            var csvString = string.Join(';', historico);

            return Ok(new {
                FileName = $"Historico_{DateTime.Now.ToString("yyyyMMDD")}.csv",
                FileStreamResult = Encoding.ASCII.GetBytes(csvString)
            });
        }

    }
}
