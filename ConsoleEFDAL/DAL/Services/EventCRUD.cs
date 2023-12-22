using DAL.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class EventCRUD
    {
        DbContextOptions<ApplicationContext> _options;

        public EventCRUD(DbContextOptions<ApplicationContext> options)
        {
            _options = options;
        }

        public void Create(Event @event)
        {
            using (ApplicationContext db = new ApplicationContext(_options))
            {
                db.Events.Add(@event);
                db.SaveChanges();
            }
        }

        public List<Event> Read()
        {
            using (ApplicationContext db = new ApplicationContext(_options))
            {
                var events = db.Events.Include(e => e.EventSections).ThenInclude(es => es.EventSectionPrice)
                    .Include(e => e.EventSections).ThenInclude(es => es.SectionSeats).ToList();
                return events;
            }
        }

        public Event Read(object Id)
        {
            using (ApplicationContext db = new ApplicationContext(_options))
            {
                return (Event)db.Find(typeof(Event), Id);
            }
        }

        public void Update(Event @event)
        {
            using (ApplicationContext db = new ApplicationContext(_options))
            {
                db.Events.Update(@event);
                db.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            using (ApplicationContext db = new ApplicationContext(_options))
            {
                Event @event = (Event)db.Find(typeof(Event), Id);
                if (@event != null)
                {
                    Delete(@event);
                }

                db.SaveChanges();
            }
        }

        public void Delete(Event @event)
        {
            using (ApplicationContext db = new ApplicationContext(_options))
            {
                db.Events.Remove(@event);
                db.SaveChanges();
            }
        }
    }
}
