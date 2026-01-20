using FluentValidation;
using FluentValidation.AspNetCore;
using Submarine.Diagnostics.Api.Validators;
using Submarine.Diagnostics.Application.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation();

builder.Services.AddValidatorsFromAssemblyContaining<DiagnosticReportRequestValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICalculatePowerConsumptionUseCase,
    CalculatePowerConsumptionUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
