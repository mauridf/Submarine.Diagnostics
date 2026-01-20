using FluentValidation;
using Submarine.Diagnostics.Api.Requests;

namespace Submarine.Diagnostics.Api.Validators;

public class DiagnosticReportRequestValidator
    : AbstractValidator<DiagnosticReportRequest>
{
    public DiagnosticReportRequestValidator()
    {
        RuleFor(x => x.Report)
            .NotEmpty()
            .WithMessage("O relatório não pode ser vazio.");

        RuleForEach(x => x.Report)
            .NotEmpty()
            .WithMessage("Nenhuma linha pode ser vazia.")
            .Matches("^[01]+$")
            .WithMessage("Cada linha deve conter apenas 0 e 1.");

        RuleFor(x => x.Report)
            .Must(AllHaveSameLength)
            .WithMessage("Todos os números binários devem ter o mesmo tamanho.");
    }

    private bool AllHaveSameLength(IEnumerable<string> report)
    {
        var list = report.ToList();
        if (!list.Any()) return true;

        int length = list.First().Length;
        return list.All(r => r.Length == length);
    }
}
