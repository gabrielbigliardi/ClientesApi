using Clientes.Aplicacao.Interfaces;
using Clientes.Aplicacao.Servicos;
using Clientes.Dominio.Interfaces;
using Clientes.Contrato.Map;
using Clientes.Dominio.Servico;
using Clientes.Infraestrutura.Interfaces;
using Clientes.Infraestrutura.Repositorio;
using Clientes.Contrato.Dto;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSwaggerGen(c =>
//{
//    c.MapType<ClienteDto>(() => new OpenApiSchema
//    {
//        Type = "object",
//        Properties = new Dictionary<string, OpenApiSchema>
//                {
//                    { "nome", new OpenApiSchema { Type = "string" } },
//                    { "endereco", new OpenApiSchema { Type = "string" } },
//                    { "cep", new OpenApiSchema { Type = "string" } },
//                    { "data_nascimento", new OpenApiSchema { Type = "string", Format = "date" } },
//                    { "telefone", new OpenApiSchema { Type = "string" } },
//                }
//    });
//});

builder.Services.AddScoped<IClientesAplService, ClientesAplService>();
builder.Services.AddScoped<IClientesService, ClientesService>();
builder.Services.AddScoped<IClientesRepositorio, ClientesRepositorio>();

// Adiciona o AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


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
