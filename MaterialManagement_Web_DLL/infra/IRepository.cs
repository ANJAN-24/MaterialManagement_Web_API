using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MaterialManagement_Web_DLL.infra
{
    public interface IRepository<T> where T : class
    {
       IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> where);
        void Insert(T entity);
        void Insert(List<T> entity);
        void Update(T entity);
        void Update(List<T> entity);
        void Delete(T entity);
        void Delete(List<T> entity);
        IQueryable<T> QueryAll();
        IQueryable<T> Where(Expression<Func<T, bool>> where); 
    }
}