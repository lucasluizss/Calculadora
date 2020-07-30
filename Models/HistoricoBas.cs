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
        }

        public DateTime Date => DateTime.Now;

        public decimal? Resultado { get; set; }
	}
}
