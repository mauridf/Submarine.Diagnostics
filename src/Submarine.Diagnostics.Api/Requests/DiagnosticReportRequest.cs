namespace Submarine.Diagnostics.Api.Requests;

public class DiagnosticReportRequest
{
    public IEnumerable<string> Report { get; set; } = [];
}
