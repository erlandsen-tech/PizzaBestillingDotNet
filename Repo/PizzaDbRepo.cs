using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PizzaBestilling.Models;

namespace PizzaBestilling.Repo
{
    public class PizzaDbRepo<T> : IPizzaDbRepo<T> where T : class
    {
        private PizzaDBContext _context = null;
        private DbSet<T> table = null;

        public PizzaDbRepo()
        {
            this._context = new PizzaDBContext();
            table = _context.Set<T>();
        }
        public PizzaDbRepo(PizzaDBContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object Id)
        {
            return table.Find(Id);
        }
        public T GetByKundeId(object KundeId)
        {
            return table.Find(KundeId);
        }
        public bool Insert(T obj)
        {
            try
            {

                table.Add(obj);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public void Delete(object Id)
        {
            T existing = table.Find(Id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}