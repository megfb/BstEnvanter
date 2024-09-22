using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class GpuDal : RepositoryBase<Gpu, EfContext>, IGpuDal
    {
        public Gpu getGpu(int id)
        {
            using (EfContext context = new EfContext())
            {
                var gpu = context.Gpu.FirstOrDefault(x => x.id == id);
                return gpu;
            }
        }
    }
}
