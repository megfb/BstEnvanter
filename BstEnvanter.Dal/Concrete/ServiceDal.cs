using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class ServiceDal : RepositoryBase<Service, EfContext>, IServiceDal
    {
        public Service getService(int id)
        {
            using (EfContext context = new EfContext())
            {
                var service = context.Service.FirstOrDefault(x => x.id == id);
                return service;
            }
        }
    }
}
