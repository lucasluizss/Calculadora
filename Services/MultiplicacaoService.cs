using Calculadora.Models;
using Calculadora.Services.Interfaces;

namespace Calculadora.Services
{
	public sealed class MultiplicacaoService : ICalculatorService
	{
		public ECodigoOperacao CodigoOperacao => ECodigoOperacao.Multiplicacao;

		public decimal Execute(IRequestViewModel request) => request.Numero1 * request.Numero2;
	}
}