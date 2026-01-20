using Submarine.Diagnostics.Domain;

namespace Submarine.Diagnostics.Application.UseCases;

public class CalculatePowerConsumptionUseCase
    : ICalculatePowerConsumptionUseCase
{
    public PowerConsumptionResult Execute(IEnumerable<string> binaryNumbers)
    {
        var numbers = binaryNumbers.ToList();

        if (!numbers.Any())
            throw new ArgumentException("Relatório não pode ser vazio.");

        int length = numbers.First().Length;
        var gammaBits = new char[length];
        var epsilonBits = new char[length];

        for (int i = 0; i < length; i++)
        {
            int ones = numbers.Count(n => n[i] == '1');
            int zeros = numbers.Count - ones;

            if (ones >= zeros)
            {
                gammaBits[i] = '1';
                epsilonBits[i] = '0';
            }
            else
            {
                gammaBits[i] = '0';
                epsilonBits[i] = '1';
            }
        }

        var gammaBinary = new string(gammaBits);
        var epsilonBinary = new string(epsilonBits);

        int gamma = Convert.ToInt32(gammaBinary, 2);
        int epsilon = Convert.ToInt32(epsilonBinary, 2);

        return new PowerConsumptionResult(
            gamma,
            epsilon,
            gamma * epsilon
        );
    }
}
