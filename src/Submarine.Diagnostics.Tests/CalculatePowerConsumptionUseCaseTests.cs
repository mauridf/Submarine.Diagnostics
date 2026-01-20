using FluentAssertions;
using Submarine.Diagnostics.Application.UseCases;
using Xunit;

namespace Submarine.Diagnostics.Tests;

public class CalculatePowerConsumptionUseCaseTests
{
    [Fact]
    public void Should_Calculate_Power_Consumption_Correctly()
    {
        var input = new[]
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        var useCase = new CalculatePowerConsumptionUseCase();

        var result = useCase.Execute(input);

        result.GammaRate.Should().Be(22);
        result.EpsilonRate.Should().Be(9);
        result.Consumption.Should().Be(198);
    }
}
