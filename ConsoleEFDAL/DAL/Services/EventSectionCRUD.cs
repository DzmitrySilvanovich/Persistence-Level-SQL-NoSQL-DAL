using DAL.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class EventSectionCRUD : IDisposable
    {
        DbContextOptions<ApplicationContext> _options;

        private bool _disposedValue;
        ApplicationContext db;

        public EventSectionCRUD(DbContextOptions<ApplicationContext> options)
        {
            _options = options;
            db = new ApplicationContext(_options);
        }

        public void Create(EventSection eventSection)
        {
            db.EventSections.Add(eventSection);
            db.SaveChanges();
        }

        public List<EventSection> Read()
        {
            return db.EventSections.Include(e => e.EventSectionPrice).ThenInclude(es => es.PriceType)
                .Include(e => e.SectionSeats).ToList();
        }

        public EventSection Read(object Id)
        {
            return (EventSection)db.Find(typeof(EventSection), Id);
        }

        public void Update(EventSection eventSection)
        {
            db.EventSections.Update(eventSection);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            EventSection eventSection = (EventSection)db.Find(typeof(EventSection), Id);
            if (eventSection != null)
            {
                Delete(eventSection);
            }

            db.SaveChanges();
        }

        public void Delete(EventSection eventSection)
        {
            db.EventSections.Remove(eventSection);
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    db?.Dispose();
                    db = null;
                }

                _disposedValue = true;
            }
        }
    }
}
