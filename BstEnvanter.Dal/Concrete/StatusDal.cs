using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class StatusDal : RepositoryBase<Status, EfContext>, IStatusDal
    {
        public Status getStatus(int id)
        {
            using (EfContext context = new EfContext())
            {
                var status = context.Status.FirstOrDefault(x => x.id == id);
                return status;
            }
        }

        public List<Status> getStatusAllWithDetails(Expression<Func<Status, bool>> filter = null)
        {
            using (EfContext context = new EfContext())
            {
                return filter == null ? context.Set<Status>().Include(x => x.Product).ThenInclude(x => x.Brand).Include(x => x.Product.Category).Include(x => x.Product.Model).Include(x => x.Personel).Include(x => x.Common).ThenInclude(x => x.department).Include(x => x.Common.CLocation).Include(x => x.Product.Cpu).Include(x => x.Product.Gpu).Include(x => x.Product.Ram).Include(x => x.Product.HardDrive).Include(x => x.Campus).ToList() :
                                        context.Set<Status>().Include(x => x.Product).ThenInclude(x => x.Brand).Include(x => x.Product.Category).Include(x => x.Product.Model).Include(x => x.Personel).Include(x => x.Common).ThenInclude(x => x.department).Include(x => x.Common.CLocation).Include(x => x.Product.Cpu).Include(x => x.Product.Gpu).Include(x => x.Product.Ram).Include(x => x.Product.HardDrive).Include(x => x.Campus).Where(filter).ToList();
            }
        }

        public List<Status> getStatusAllWithDetailsByCategory(Expression<Func<Status, bool>> filter = null)
        {
            using (EfContext context = new EfContext())
            {
                return filter == null ? context.Set<Status>().Include(x => x.Product).ThenInclude(x => x.Brand).Include(x => x.Product.Category).Include(x => x.Product.Model).Include(x => x.Personel).Include(x => x.Common).ThenInclude(x => x.department).Include(x => x.Common.CLocation).Include(x => x.Product.Cpu).Include(x => x.Product.Gpu).Include(x => x.Product.Ram).Include(x => x.Product.HardDrive).ToList() :
                                        context.Set<Status>().Include(x => x.Product).ThenInclude(x => x.Brand).Include(x => x.Product.Category).Include(x => x.Product.Model).Include(x => x.Personel).Include(x => x.Common).ThenInclude(x => x.department).Include(x => x.Common.CLocation).Include(x => x.Product.Cpu).Include(x => x.Product.Gpu).Include(x => x.Product.Ram).Include(x => x.Product.HardDrive).Where(filter).ToList();
            }
        }

        public Status getStatusWithDetail(int id)
        {
            using (EfContext context = new EfContext())
            {
                var status = context.Status.Include(x => x.Product).ThenInclude(x => x.Brand).Include(x => x.Product.Category).Include(x => x.Product.Model).Include(x => x.Personel).ThenInclude(x => x.Department).Include(x => x.Personel.Sex).Include(x => x.Common).ThenInclude(x => x.department).Include(x => x.Common.CLocation).Include(x => x.Campus).Include(x => x.Product.Cpu).Include(x => x.Product.Gpu).Include(x => x.Product.Ram).Include(x => x.Product.HardDrive).Include(x => x.Personel.CLocation).Include(x => x.Service).FirstOrDefault(x => x.id == id);
                return status;
            }
        }
    }
}
