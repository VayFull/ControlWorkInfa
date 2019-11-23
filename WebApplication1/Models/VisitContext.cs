using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
namespace WebApplication1.Models
{
    public class VisitContext : DbContext
    {
        public VisitContext()
        {
            Database.EnsureCreated(); //какой-то конструктор, 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1234QWER+"); //строка подключения
        }

        public DbSet<VisitModel> visitmodel { get; set; }
    }
}