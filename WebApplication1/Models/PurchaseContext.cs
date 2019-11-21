using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace WebApplication1.Models
{
    public class PurchaseContext:DbContext
    {
        public static readonly ILoggerFactory loggerFactory = new LoggerFactory(new[] {
            new ConsoleLoggerProvider((_, __) => true, true)
        }); //для логгера, у меня не работает


        public PurchaseContext()
        {
            Database.EnsureCreated(); //какой-то конструктор, 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)  //tie-up DbContext with LoggerFactory object(для логгирования)
                .EnableSensitiveDataLogging()
                .UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1234QWER+"); //строка подключения
        }

        public DbSet<Purchase> purchases { get; set; } //таблица purchases непосредственно в datagrip
    }
}