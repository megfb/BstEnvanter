using BstEnvanter.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Abstract
{
    public interface IRepositoryBase<T> where T : class, IEntity
    {
        void add(T Entity);
        void remove(T Entity);
        void update(T Entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
    }
}
