using Calculadora.Models;
using Calculadora.Services.Interfaces;

namespace Calculadora.Services
{
	public sealed class SubtracaoService : ICalculatorService
	{
		public ECodigoOperacao CodigoOperacao => ECodigoOperacao.Subtracao;

		public decimal Execute(RequestViewModel request) => request.Numero1 - request.Numero2;
	}
}