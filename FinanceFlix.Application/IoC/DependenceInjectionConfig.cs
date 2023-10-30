using FinanceFlix.Application.Interfaces;
using FinanceFlix.Application.Services;
using FinanceFlix.Data.Context;
using FinanceFlix.Data.Repositories;
using FinanceFlix.Domain.Interfaces.IRepositories;
using FinanceFlix.Domain.Interfaces.IServices;
using FinanceFlix.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using FinanceFlix.Domain.Services.AWS;
using FinanceFlix.Domain.Interfaces.IServices.IAWS;

namespace FinanceFlix.Application.IoC
{
    public static class DependenceInjectionConfig
    {

        public static void AddResolveDependecies(this IServiceCollection services)
        {


            //Application
            #region Inversão de Controles - Services
            services.AddScoped<ICategoriaApplicationService, CategoriaApplicationService>();
            services.AddScoped<ICursoApplicationService, CursoApplicationService>();
            services.AddScoped<IVideoApplicationService, VideoApplicationService>();
            #endregion

            //Domain
            #region Inversão de Controles - Domain Services 
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<ICursoService, CursoService>();
            #endregion

            #region Inversão de Controles - AWS Services

            services.TryAddScoped<IStorageService, StorageService>();

            #endregion


            #region Inversão de Controles - Domain Repositories
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<ICursoVideoRepository, CursoVideoRepository>();
            #endregion


            //Data
            services.AddScoped<DataContext>();

            #region Conexão com banco de dados
            //Conexão com o banco de dados - Dev
            /* services.AddDbContext<DataContext>(options =>
            {
                options.UseOracle("User Id=C##SYS_DBA;Password=senha123;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SID=xe)))");
            });*/




            //Conexão com o banco de dados - Produção
      
            services.AddDbContext<DataContext>(options =>
            {
                options.UseOracle("User Id=RM96330;Password=140400;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SID=ORCL)))");
            });

            #endregion




        }


    }
}
