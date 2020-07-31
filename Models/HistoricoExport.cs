using System;
using Calculadora.Controllers;
using Calculadora.Notations;

namespace Calculadora.Models
{
    public class HistoricoViewModel : TitleToExport, IRequestViewModel
    {
        public HistoricoViewModel(RequestViewModel request, decimal resultado)
        {
            Numero1 = request.Numero1;
            Operacao = request.Operacao;
            Numero2 = request.Numero2;
            Resultado = resultado;
            Date = DateTime.Now;
        }

        [TitleToExport("Data")]
        public DateTime Date { get; set; }

        [TitleToExport("Numero 1")]
		public decimal Numero1 { get; set; }

        [TitleToExport("Operação")]
		public ECodigoOperacao Operacao { get; set; }

        [TitleToExport("Numero 2")]
		public decimal Numero2 { get; set; }

        [TitleToExport("Resultado")]
        public decimal Resultado { get; set; }
	}
}
