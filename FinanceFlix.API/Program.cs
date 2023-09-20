using FinanceFlix.Data.Context;
using FinanceFlix.Data.Repositories;
using FinanceFlix.Domain.Interfaces.IRepositories;
using FinanceFlix.Domain.Interfaces.IServices;
using FinanceFlix.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Conexão com o banco de dados
#region Conexão com o banco de dados
//habilitar para desenvolvimento
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnectionLOCAL");

//habilitar para produção
//var connectionString = builder.Configuration.GetConnectionString("DatabaseConnectionFIAP");
builder.Services.AddDbContext<DataContext>(options => options.UseOracle(connectionString).EnableSensitiveDataLogging(true));
#endregion


//Inversão de Controles - Repositories
#region Inversão de Controles - Repositories
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IVideoRepository, VideoRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
#endregion

//Inversão de Controles - Services
#region Inversão de Controles - Services
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddScoped<ICursoService, CursoService>();
#endregion

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
