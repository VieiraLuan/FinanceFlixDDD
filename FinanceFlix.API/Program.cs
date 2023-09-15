using FinanceFlix.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Conex�o com o banco de dados
#region Conex�o com o banco de dados
//habilitar para desenvolvimento
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnectionLOCAL");

//habilitar para produ��o
//var connectionString = builder.Configuration.GetConnectionString("DatabaseConnectionFIAP");
builder.Services.AddDbContext<DataContext>(options => options.UseOracle(connectionString).EnableSensitiveDataLogging(true));
#endregion


//Invers�o de Controles
#region Invers�o de Controles
// builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
#endregion

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
