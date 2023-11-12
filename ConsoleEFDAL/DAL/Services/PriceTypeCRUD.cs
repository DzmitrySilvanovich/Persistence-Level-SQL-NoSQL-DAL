using DAL.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class PriceTypeCRUD : IDisposable
    {
        DbContextOptions<ApplicationContext> _options;

        private bool _disposedValue;
        ApplicationContext db;

        public PriceTypeCRUD(DbContextOptions<ApplicationContext> options)
        {
            _options = options;
            db = new ApplicationContext(_options);
        }

        public void Create(PriceType priceType)
        {
            db.PriceTypes.Add(priceType);
            db.SaveChanges();

        }

        public List<PriceType> Read()
        {
            return db.PriceTypes.ToList();
        }

        public PriceType Read(object Id)
        {
            return (PriceType)db.Find(typeof(PriceType), Id);
        }

        public void Update(PriceType priceType)
        {
            db.PriceTypes.Update(priceType);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            PriceType priceType = (PriceType)db.Find(typeof(PriceType), Id);
            if (priceType != null)
            {
                Delete(priceType);
            }

            db.SaveChanges();
        }

        public void Delete(PriceType priceType)
        {
            db.PriceTypes.Remove(priceType);
            db.SaveChanges();
        }

        // Public implementation of Dispose pattern callable by consumers.
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
