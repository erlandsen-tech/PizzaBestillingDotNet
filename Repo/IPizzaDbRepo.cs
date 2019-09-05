using System;
using System.Collections.Generic;
namespace PizzaBestilling.Repo
{
    public interface IPizzaDbRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        T GetByKundeId(object KundeId);
        bool Insert(T obj);
        void Delete(object Id);
        void Save();
    }
}
