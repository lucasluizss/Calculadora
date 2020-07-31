using System;

namespace Calculadora.Models
{
    public class HistoricoBaseViewModel : RequestViewModel
    {
        public HistoricoBaseViewModel(RequestViewModel request, decimal resultado)
        {
            Numero1 = request.Numero1;
            Operacao = request.Operacao;
            Numero2 = request.Numero2;
            Resultado = resultado;
            Date = DateTime.Now;
        }

        public DateTime Date { get; set; }

        public decimal? Resultado { get; set; }
	}
}
