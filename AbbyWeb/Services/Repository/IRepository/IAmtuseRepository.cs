using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AbbyWeb.Services.Repository.IRepository
{
    public interface IAmtuseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> RetrievedAll(Expression<Func<TEntity,bool>> filterData = null, string navigationProperties = null,
           Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderBy = null);
        TEntity Add(TEntity entityToAdd);
        void Delete(TEntity entity);
        void Delete(int id);
        TEntity Find(TEntity entityToFind);
        TEntity Find(int id);

    }
}
