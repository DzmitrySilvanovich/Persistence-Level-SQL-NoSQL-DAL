using DAL.Domain;
using DAL.Services;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace DAL
{
    public class TicketServise
    {
        public EventCRUD EventCRUD => new EventCRUD(options);
        public PriceTypeCRUD PriceTypeCRUD => new PriceTypeCRUD(options);
        public EventSectionCRUD EventSectionCRUD => new EventSectionCRUD(options);
        public EventSectionPriceCRUD EventSectionPriceCRUD => new EventSectionPriceCRUD(options);
        public SectionSeatCRUD SectionSeatCRUD => new SectionSeatCRUD(options);
        public EventSeatPriceCRUD EventSeatPriceCRUD => new EventSeatPriceCRUD(options);

        string _connectionString;
        DbContextOptions<ApplicationContext> options;

        public TicketServise(string connectionString)
        {
            _connectionString = connectionString;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            options = optionsBuilder
                    .UseSqlServer(_connectionString)
            .Options;

        }
    }
}