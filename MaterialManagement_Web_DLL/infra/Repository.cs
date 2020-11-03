using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MaterialManagement_Web_DLL.infra
{
   public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return entities.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return entities.Where(where).FirstOrDefault();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            //context.SaveChanges();
        }
        public void Insert(List<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.AddRange(entity);
            //context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            //context.SaveChanges();
        }

        public void Update(List<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.UpdateRange(entity);
            //context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            //context.SaveChanges();
        }
        public void Delete(List<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.RemoveRange(entity);
            //context.SaveChanges();
        } 

        public IQueryable<T> QueryAll()
        {
            return entities;
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            return entities.Where(where);
        }
    }
}