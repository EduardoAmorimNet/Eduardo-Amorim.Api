using Eduardo_Amorim.Api.Aplicacao;
using Eduardo_Amorim.Api.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Server.HttpSys;
using System.Diagnostics.CodeAnalysis;

[assembly: ExcludeFromCodeCoverage]
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISimulacaoServicoCalculo, ServicoSimulacaoCalculo>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
