using Calculadora.Models;
using Calculadora.Services.Interfaces;

namespace Calculadora.Services
{
	public sealed class SubtracaoService : ICalculatorService
	{
		public ECodigoOperacao CodigoOperacao => ECodigoOperacao.Subtracao;

		public decimal Execute(IRequestViewModel request) => request.Numero1 - request.Numero2;
	}
}