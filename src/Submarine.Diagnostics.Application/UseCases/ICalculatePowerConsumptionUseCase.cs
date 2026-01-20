using Submarine.Diagnostics.Domain;

namespace Submarine.Diagnostics.Application.UseCases;

public interface ICalculatePowerConsumptionUseCase
{
    PowerConsumptionResult Execute(IEnumerable<string> binaryNumbers);
}
