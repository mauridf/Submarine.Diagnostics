namespace Submarine.Diagnostics.Domain;

public record PowerConsumptionResult(
    int GammaRate,
    int EpsilonRate,
    int Consumption
);
