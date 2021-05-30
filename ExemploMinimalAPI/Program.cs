using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
await using var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", (Func<object>)(() =>
{
    const string mensagem = "Exemplo de uso de Minimal APIs em ASP.NET Core";
    var horario = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
    Console.WriteLine($"[{horario}] Recebida requisição - {mensagem}");
    return new
    {
        Saudacao = "Bem-vindo ao .NET 6 Preview 4!",
        Descricao = mensagem,
        Horario = horario
    };
}));

await app.RunAsync();
