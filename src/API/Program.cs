using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Service.MediatR.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Injeção de dependência
builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();

// Registro do MediatR - Procura automaticamente os Handlers na solução
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllAnimesQueryHandler).Assembly));

builder.Logging.AddConsole();

// Adicionar o DbContext ao contêiner de serviços
builder.Services.AddDbContext<AnimeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Anime API",
        Version = "v1",
        Description = "Uma API para gerenciar animes",
        Contact = new OpenApiContact
        {
            Name = "Seu Nome",
            Email = "seuemail@example.com"
        }
    });
});

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Anime API v1");
        //c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();