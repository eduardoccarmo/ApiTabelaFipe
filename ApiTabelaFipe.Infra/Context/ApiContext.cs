using ApiTabelaFipe.Domain.Models;
using ApiTabelaFipe.Infra.Mappings;
using Microsoft.EntityFrameworkCore;


namespace ApiTabelaFipe.Infra.Context
{
    public class ApiContext : DbContext
    {
        public DbSet<Marca> Marcas { get; set; }
        //public DbSet<Modelo> Modelos { get; set; }

        private readonly string _connectionString = "Server=localhost;Port=3306;Database=fipe;Uid=root;Pwd=root;";

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApiContext).Assembly); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString)));
        }
    }
}
