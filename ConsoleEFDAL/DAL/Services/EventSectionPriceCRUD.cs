using DAL.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class EventSectionPriceCRUD
    {
        DbContextOptions<ApplicationContext> _options;

        private bool _disposedValue;
        ApplicationContext db;

        public EventSectionPriceCRUD(DbContextOptions<ApplicationContext> options)
        {
            _options = options;
            db = new ApplicationContext(_options);
        }

        public void Create(EventSectionPrice eventSectionPrice)
        {
            db.EventSectionPrices.Add(eventSectionPrice);
            db.SaveChanges();
        }

        public List<EventSectionPrice> Read()
        {
            // return db.EventSectionPrices.Include(e => e.PriceType).Include(e => e.EventSection).ToList();
            return db.EventSectionPrices.ToList();
        }

        public EventSectionPrice Read(object Id)
        {
            return (EventSectionPrice)db.Find(typeof(EventSectionPrice), Id);
        }

        public void Update(EventSectionPrice eventSectionPrice)
        {
            db.EventSectionPrices.Update(eventSectionPrice);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            EventSectionPrice eventSectionPrice = (EventSectionPrice)db.Find(typeof(EventSectionPrice), Id);
            if (eventSectionPrice != null)
            {
                Delete(eventSectionPrice);
            }

            db.SaveChanges();
        }

        public void Delete(EventSectionPrice eventSectionPrice)
        {
            db.EventSectionPrices.Remove(eventSectionPrice);
            db.SaveChanges();
        }

        public IQueryable<EventSectionPrice> Get(Expression<Func<EventSectionPrice, bool>> condition, string includeProperties = "")
        {
            IQueryable<EventSectionPrice> query = db.Set<EventSectionPrice>();
            if (condition != null)
            {
                query = query.Where(condition);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query.AsQueryable();
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
