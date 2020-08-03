using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NetCoreAPI.Data;
using NetCoreAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCoreAPI.Services
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DenariusAPIContext context;
        internal DbSet<TEntity> dbset;

        public BaseRepository(DenariusAPIContext context)
        {
            this.context = context;
            this.dbset = context.Set<TEntity>();
        }
        public void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbset.Attach(entityToDelete);
            }

            dbset.Remove(entityToDelete);
        }

        public void Delete(object id)
        {
            TEntity entitytoDelete = dbset.Find(id);
            Delete(entitytoDelete);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach(var incluideProperty in includeProperties.Split(new char[] {',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluideProperty);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity GetById(object id)
        {
            return dbset.Find(id);
        }

        public void Insert(TEntity entityToInsert)
        {
            dbset.Add(entityToInsert);            
        }

        public void Update(TEntity entitytoUpdate)
        {
            dbset.Attach(entitytoUpdate);
            context.Entry(entitytoUpdate).State = EntityState.Modified;
        }
    }
}
