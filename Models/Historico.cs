using System;

namespace Calculadora.Models
{
    public class HistoricoViewModel : RequestViewModel
    {
        public HistoricoViewModel(RequestViewModel request, decimal resultado)
        {
            Numero1 = request.Numero1;
            Numero2 = request.Numero2;
            Operacao = request.Operacao;
            Resultado = resultado;
        }

        public DateTime Date => DateTime.Now;

        public decimal Resultado { get; set; }
    }
}
