using FluentValidation;

namespace Submarine.Diagnostics.Api.Validators;

public class DiagnosticReportValidator
    : AbstractValidator<IEnumerable<string>>
{
    public DiagnosticReportValidator()
    {
        RuleFor(report => report)
            .NotEmpty()
            .WithMessage("O relatório não pode ser vazio.");

        RuleForEach(report => report)
            .NotEmpty()
            .WithMessage("Nenhuma linha pode ser vazia.")
            .Matches("^[01]+$")
            .WithMessage("Cada linha deve conter apenas 0 e 1.");

        RuleFor(report => report)
            .Must(AllHaveSameLength)
            .WithMessage("Todos os números binários devem ter o mesmo tamanho.");
    }

    private bool AllHaveSameLength(IEnumerable<string> report)
    {
        var list = report.ToList();
        int length = list.First().Length;
        return list.All(r => r.Length == length);
    }
}
