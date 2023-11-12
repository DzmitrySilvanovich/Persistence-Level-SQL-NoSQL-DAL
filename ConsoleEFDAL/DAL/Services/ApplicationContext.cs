using DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<PriceType> PriceTypes { get; set; } = null!;
        public DbSet<EventSectionPrice> EventSectionPrices { get; set; } = null!;
        public DbSet<SectionSeat> SectionSeats { get; set; } = null!;
        public DbSet<EventSection> EventSections { get; set; } = null!;
        public DbSet<EventSeatPrice> EventSeatPrices { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
          //          Database.EnsureDeleted(); // гарантируем, что бд удалена
          //          Database.EnsureCreated(); // гарантируем, что бд будет создана
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message), new[] { DbLoggerCategory.Database.Command.Name },
                      LogLevel.Information);
        }
    }
}
