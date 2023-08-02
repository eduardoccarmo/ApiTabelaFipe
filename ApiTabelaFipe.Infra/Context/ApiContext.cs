using Microsoft.EntityFrameworkCore;

namespace ApiTabelaFipe.Infra.Context
{
    public class ApiContext : DbContext
    {


        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
