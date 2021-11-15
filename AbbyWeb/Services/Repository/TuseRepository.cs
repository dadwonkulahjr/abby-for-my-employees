using AbbyWeb.Data;
using AbbyWeb.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AbbyWeb.Services.Repository
{
    public class TuseRepository<GetEntity> : IAmtuseRepository<GetEntity> where GetEntity : class
    {
        internal DbSet<GetEntity> _doAllQueries;
        public TuseRepository(ApplicationDbContext applicationDbContext)
        {
            _doAllQueries = applicationDbContext.Set<GetEntity>();
        }
        public GetEntity Add(GetEntity entityToAdd)
        {
            _doAllQueries.Add(entityToAdd);
            return entityToAdd;
        }

        public void Delete(GetEntity entity)
        {
            _doAllQueries.Remove(entity);
        }

        public void Delete(int id)
        {
            var result = _doAllQueries.Find(id);
            if (result != null)
            {
                _doAllQueries.Remove(result);
            }
        }

        public GetEntity Find(GetEntity entityToFind)
        {
            var find = _doAllQueries.Find(entityToFind);
            if (find != null)
            {
                return find;
            }

            return null;
        }

        public GetEntity Find(int id)
        {
            return _doAllQueries.Find(id);
        }

        public IEnumerable<GetEntity> RetrievedAll(Expression<Func<GetEntity, bool>> filterData = null, string navigationProperties = null, Func<IQueryable<GetEntity>, IOrderedQueryable<GetEntity>> orderBy = null)
        {
            IQueryable<GetEntity> query = _doAllQueries;

            if (filterData != null)
            {
                query = query.Where(filterData);
            }


            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            if (navigationProperties != null)
            {
                foreach (var property in navigationProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }


            return query.ToList();
        }
    }
}
