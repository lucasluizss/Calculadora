using Calculadora.Models;
using Calculadora.Services.Interfaces;

namespace Calculadora.Services
{
	public sealed class SomaService : ICalculatorService
	{
		public ECodigoOperacao CodigoOperacao => ECodigoOperacao.Soma;

		public decimal Execute(IRequestViewModel request) => request.Numero1 + request.Numero2;
	}
}