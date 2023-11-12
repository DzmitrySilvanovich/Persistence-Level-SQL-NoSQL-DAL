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
    public class SectionSeatCRUD : IDisposable
    {
        DbContextOptions<ApplicationContext> _options;

        private bool _disposedValue;
        ApplicationContext db;

        public SectionSeatCRUD(DbContextOptions<ApplicationContext> options)
        {
            _options = options;
            db = new ApplicationContext(_options);
        }

        public void Create(SectionSeat sectionSeat)
        {
            db.SectionSeats.Add(sectionSeat);
            db.SaveChanges();
        }

        public List<SectionSeat> Read()
        {
            return db.SectionSeats.ToList();
        }

        public SectionSeat Read(object Id)
        {
            return (SectionSeat)db.Find(typeof(SectionSeat), Id);
        }

        public void Update(SectionSeat sectionSeat)
        {
            db.SectionSeats.Update(sectionSeat);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            SectionSeat sectionSeat = (SectionSeat)db.Find(typeof(SectionSeat), Id);
            if (sectionSeat != null)
            {
                Delete(sectionSeat);
            }

            db.SaveChanges();
        }

        public void Delete(SectionSeat sectionSeat)
        {
            db.SectionSeats.Remove(sectionSeat);
            db.SaveChanges();
        }

        public IQueryable<SectionSeat> Get(Expression<Func<SectionSeat, bool>> condition, string includeProperties = "")
        {
            IQueryable<SectionSeat> query = db.Set<SectionSeat>();
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
