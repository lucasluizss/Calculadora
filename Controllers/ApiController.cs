using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
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
        private static List<HistoricoBaseViewModel> historicoList = new List<HistoricoBaseViewModel>(0);

        private readonly ILogger<ApiController> _logger;

        public ApiController(
            ILogger<ApiController> logger,
            IEnumerable<ICalculatorService> calculatorServices
        ) {
            _calculatorServices = calculatorServices;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<HistoricoBaseViewModel> Get() => historicoList;

        [HttpPost]
        public ActionResult Calcular([FromBody] RequestViewModel request)
        {
            var service = _calculatorServices.FirstOrDefault(c => c.CodigoOperacao == request.Operacao) ?? throw new ArgumentException("Service not found");

            var response = service.Execute(request);

            var historico = new HistoricoBaseViewModel(request, response);

            _logger.LogInformation("history", historico);

            historicoList.Add(historico);

            return Ok(response);
        }

        // [HttpPost]
        // public FileResult Download()
        // {
        //     var fileName = $"Historico_{DateTime.Now.ToString("yyyyMMDD")}.csv";
        //     var csvString = string.Concat(historicoList.Select(h => $"{h.Date};{h.Numero1};{h.Operacao};{h.Numero2};{h.Resultado};"));

        //     return new FileContentResult(GetFile(csvString), "application/octet-stream");
        // }

        private static byte[] GetFile(string data)
        {
            var sb = new StringBuilder();

            var campos = GetCampos<HistoricoViewModel>();

            foreach (var itemCampo in campos)
            {
                var valor = GetLayout(itemCampo);

                sb.Append($"{valor.Title};");
            }

            sb.Append(Environment.NewLine);

            sb.Append(data);

            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms, Encoding.UTF8))
                {
                    writer.WriteLine(sb.ToString());
                }

                return ms.ToArray();
            }
        }

        private static IEnumerable<PropertyInfo> GetCampos<T>()
        {
            return typeof(T).GetProperties().Where(x => x.CustomAttributes.Any()).ToList();
        }

        private static TitleToExport GetLayout(PropertyInfo field)
        {
            return ((TitleToExport)field.GetCustomAttributes(typeof(TitleToExport), true).First());
        }
    }

    public class TitleToExport : ValidationAttribute
    {
        public readonly string Title;

        public readonly Type FormatType;

        public TitleToExport() { }

        public TitleToExport(string title) => Title = title;

        // public TitleToExport(string title, Type formatType)
        // {
        //     Title = title;
        //     FormatType = formatType;
        // }
    }
}
