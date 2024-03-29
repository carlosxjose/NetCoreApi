﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCoreAPI.Services
{
    public interface IRepository<TEntity> where TEntity: class
    {
        void Insert(TEntity entityToInsert);
        void Update(TEntity entitytoUpdate);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetById(object id);
        void Delete(TEntity entityToDelete);

        void Delete(object id);
    }
}
