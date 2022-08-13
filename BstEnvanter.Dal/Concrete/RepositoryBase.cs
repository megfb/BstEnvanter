using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void add(TEntity Entity)
        {
            using (TContext context = new TContext())
            {
                context.Add(Entity);
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ?
                    context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void remove(TEntity Entity)
        {
            using (TContext context = new TContext())
            {
                var deleteEntity = context.Entry(Entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void update(TEntity Entity)
        {
            using (TContext context = new TContext())
            {
                context.Update(Entity);
                context.SaveChanges();
            }
        }
    }
}
