using Microsoft.EntityFrameworkCore;
using WebAPIRepositoryPattern.Models;

namespace WebAPIRepositoryPattern.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<FuncionarioModel> FuncionariosDB { get; set; }

    }
}
