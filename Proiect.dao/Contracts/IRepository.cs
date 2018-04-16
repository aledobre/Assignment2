using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.dal.Contracts
{
    public interface IRepository<T, TKey>
        where T : class
    {
        void Add(T obj);

        void Update(T obj);

        T GetByKey(TKey key);

        IQueryable<T> GetAll();

        void Delete(TKey key);

        void Delete(T obj);

        void SaveChanges();

    }
}
