using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Abstract
{
    public interface IStatusDal : IRepositoryBase<Status>
    {
        List<Status> getStatusAllWithDetails(Expression<Func<Status, bool>> filter = null);
        List<Status> getStatusAllWithDetailsByCategory(Expression<Func<Status, bool>> filter = null);
        Status getStatusWithDetail(int id);
        Status getStatus(int id);
    }
}
