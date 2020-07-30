namespace Calculadora.Models
{
    public interface IRequestViewModel
    {
        decimal Numero1 { get; set; }
        decimal Numero2 { get; set; }
        ECodigoOperacao Operacao { get; set; }
    }

    public class RequestViewModel : IRequestViewModel
    {
        public decimal Numero1 { get; set; }
        public decimal Numero2 { get; set; }
        public ECodigoOperacao Operacao { get; set; }
    }
}