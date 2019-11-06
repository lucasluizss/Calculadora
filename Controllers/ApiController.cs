using System;
using System.Collections.Generic;
using System.Linq;
using Calculadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calculadora.Controllers
{
    [ApiController]
    [Route("api")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<HistoricoViewModel> historico = new List<HistoricoViewModel>(0);

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<HistoricoViewModel> Get() => historico;

        [HttpPost]
        [Route("Calcular")]
        public ActionResult Calcular([FromBody] RequestViewModel request)
        {
            var response = Processar(request);

            historico.Add(new HistoricoViewModel(request, response));

            return Ok(response);
        }

        private static decimal Processar(RequestViewModel request)
        {
            switch (request.Operacao)
            {
                case 1:
                    return request.Numero1 + request.Numero2;
                case 2:
                    return request.Numero1 - request.Numero2;
                case 3:
                    return request.Numero1 * request.Numero2;
                case 4:
                    return request.Numero1 / request.Numero2;
                default:
                    return 0;
            }
        }
    }
}
