using DAL;
using DAL.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEFDAL
{
    public class Work
    {
        public void Doing()
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");

            TicketServise ticketServise = new(connectionString);

            var evntCRUD = ticketServise.EventCRUD;
            var priceTypeCRUD = ticketServise.PriceTypeCRUD;
            var eventSectionCRUDD = ticketServise.EventSectionCRUD;
            var eventSectionPriceCRUD = ticketServise.EventSectionPriceCRUD;
            var SectionSeatCRUD = ticketServise.SectionSeatCRUD;
            var EventSeatPriceCRUD = ticketServise.EventSeatPriceCRUD;


            var @event = new Event
            {
                Name = "Event1",
                Venue = "Venue1",
                Date = DateTime.Now,
            };
            evntCRUD.Create(@event);

            @event = new Event
            {
                Name = "Event2",
                Venue = "Venue2",
                Date = DateTime.Now,
            };
            evntCRUD.Create(@event);

            @event = new Event
            {
                Name = "Event3",
                Venue = "Venue3",
                Date = DateTime.Now,
            };
            evntCRUD.Create(@event);

            var priceType = new PriceType
            {
                Name = "Adult"
            };
            priceTypeCRUD.Create(priceType);

            priceType = new PriceType
            {
                Name = "Child"
            };
            priceTypeCRUD.Create(priceType);

            priceType = new PriceType
            {
                Name = "VIP"
            };
            priceTypeCRUD.Create(priceType);

            var events = evntCRUD.Read();
            var priceTypes = priceTypeCRUD.Read();

            var evetSection = new EventSection
            {
                Name = "Section1",
                EventId = events.First().Id,
            };
            eventSectionCRUDD.Create(evetSection);

            SectionSeat sectionSeat = new()
            {
                Row = 1,
                Seat = 2,
                State = 3,
                EventSectionId = evetSection.Id,
            };

            SectionSeatCRUD.Create(sectionSeat);

            EventSectionPrice eventSectionPrice = new()
            {
                Price = 2.34m,
                EventSectionId = evetSection.Id,
                PriceTypeId = priceTypes.First().Id
            };

            var esp2 = eventSectionPriceCRUD.Read();

            var esp = eventSectionPriceCRUD.Get(e => e.EventSectionId == 1 && e.PriceTypeId == 1).ToList();

            if (esp?.Count() > 0)
            {
                eventSectionPriceCRUD.Update(eventSectionPrice);
            }
            else
            {
                eventSectionPriceCRUD.Create(eventSectionPrice);
            }

            events = evntCRUD.Read();

            foreach (var evnt in events)
            {
                Console.WriteLine($"{evnt?.Name}, {evnt?.Venue}");

                foreach (var item in evnt?.EventSections)
                {
                    Console.WriteLine($"   {item?.Name}");
                }
            }
        }
    }
}

