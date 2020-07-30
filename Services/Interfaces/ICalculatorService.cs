using Calculadora.Models;

namespace Calculadora.Services.Interfaces
{
	public interface ICalculatorService
	{
		ECodigoOperacao CodigoOperacao { get; }

		decimal Execute(IRequestViewModel request);
	}
}