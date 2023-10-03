using FinanceFlix.API.Entities;
using FinanceFlix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinanceFlix.Data.Context
{
    public class DataContext : DbContext //Classe que herda de DbContext
    {

        //Construtor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

            
        }

        //Mapeamento das tabelas

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Trilha> Trilhas { get; set; }
        public DbSet<CursoVideo> CursosVideos { get; set; }
        //public DbSet<CursoTrilha> CursosTrilhas { get; set; }


      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Utilizar mapeamento
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
          


            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {



            if (!optionsBuilder.IsConfigured)
            {


                //Banco de dados Oracle Desenvolvimento
                optionsBuilder.UseOracle(GetDatabaseConnectionLOCAL());

                //Banco de dados Oracle "Produção"
                //optionsBuilder.UseOracle(GetDatabaseConnectionFIAP());

                base.OnConfiguring(optionsBuilder);
            }


        }



        //Strings de conexão com o banco de dados

        public string GetDatabaseConnectionFIAP()
        {

            return "User Id=RM96330;Password=140400;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SID=ORCL)))";

        }

        public string GetDatabaseConnectionLOCAL()
        {

            return "User Id=C##SYS_DBA;Password=senha123;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SID=xe)))";

        }



    }
}
