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
    public class EventSeatPriceCRUD
    {
        DbContextOptions<ApplicationContext> _options;

        private bool _disposedValue;
        ApplicationContext db;

        public EventSeatPriceCRUD(DbContextOptions<ApplicationContext> options)
        {
            _options = options;
            db = new ApplicationContext(_options);
        }

        public void Create(EventSeatPrice eventSeatPrice)
        {
            db.EventSeatPrices.Add(eventSeatPrice);
            db.SaveChanges();
        }

        public List<EventSeatPrice> Read()
        {
            return db.EventSeatPrices.ToList();
        }

        public EventSeatPrice Read(object Id)
        {
            return (EventSeatPrice)db.Find(typeof(EventSeatPrice), Id);
        }

        public void Update(EventSeatPrice eventSeatPrice)
        {
            db.EventSeatPrices.Update(eventSeatPrice);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            EventSeatPrice eventSeatPrice = (EventSeatPrice)db.Find(typeof(EventSeatPrice), Id);
            if (eventSeatPrice != null)
            {
                Delete(eventSeatPrice);
            }

            db.SaveChanges();
        }

        public void Delete(EventSeatPrice eventSeatPrice)
        {
            db.EventSeatPrices.Remove(eventSeatPrice);
            db.SaveChanges();
        }

        public IQueryable<EventSeatPrice> Get(Expression<Func<EventSeatPrice, bool>> condition, string includeProperties = "")
        {
            IQueryable<EventSeatPrice> query = db.Set<EventSeatPrice>();
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
