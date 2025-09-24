using DesafioAPI.Infra.Percistencia;
using DesafioAPI.Dominio.Repositorio;
using DesafioAPI.Infra.Repositorio;
using Microsoft.EntityFrameworkCore;
using Serilog;
using MediatR;
using FluentValidation;
using FluentValidation.AspNetCore;
using DesafioAPI.Aplicacao.Usuarios.AtualizarUsuario; // <- para achar o Validator

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) =>
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .WriteTo.Console()
);

// Add services to the container.
builder.Services.AddControllers();

// Registro do FluentValidation (novo jeito)
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<AtualizarUsuarioDtoValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro do DbContext com PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro do repositório
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

// Registro do MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

// Registro do RandomUserService
builder.Services.AddHttpClient<DesafioAPI.Aplicacao.Servicos.RandomUserService>();

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
