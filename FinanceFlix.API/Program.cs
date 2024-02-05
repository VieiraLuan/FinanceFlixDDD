using FinanceFlix.API.Swagger;
using FinanceFlix.Application.Auth;
using FinanceFlix.Application.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Add Authentication and Authorization
var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

//Adicionando versionamento
builder.Services.AddApiVersioning(
    x =>
    {
        x.AssumeDefaultVersionWhenUnspecified = true;
        x.DefaultApiVersion = new ApiVersion(1, 0);
    });



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddVersionedApiExplorer(
    setup =>
    {
        setup.GroupNameFormat = "'v'VVV";
        setup.SubstituteApiVersionInUrl = true;
    }

    );
builder.Services.AddSwaggerGen(
    c => c.OperationFilter<SwaggerDefaultValues>()
);

//Adding Swagger Dependecies
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();



//Serilog

//Criando configuração servilog recuperando do appsettings.json

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

// Criando configuração Serilog recuperando do appsettings.

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();





//Add Dependence Injection
builder.Services.AddResolveDependecies();

//Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost4200", builder => builder
        .WithOrigins("http://localhost:4200") 
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});





var app = builder.Build();
var version = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseCors("AllowLocalhost4200");

// Add Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            foreach (var description in version.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    $"Finance Flix API - {description.GroupName.ToUpper()}");
            }
        }
        );

}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
