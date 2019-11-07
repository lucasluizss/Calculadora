using System;
using System.Collections.Generic;
using System.Linq;
using Calculadora.Models;
using Calculadora.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calculadora.Controllers
{
    [ApiController]
    [Route("api")]
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
        [Route("Get")]
        public IEnumerable<HistoricoViewModel> Get() => historico;

        [HttpPost]
        [Route("Calcular")]
        public ActionResult Calcular([FromBody] RequestViewModel request)
        {
            var service = _calculatorServices.FirstOrDefault(c => c.CodigoOperacao == request.Operacao) ?? throw new ArgumentException("Service not found");

            var response = service.Execute(request);

            historico.Add(new HistoricoViewModel(request, response));

            return Ok(response);
        }
    }
}
