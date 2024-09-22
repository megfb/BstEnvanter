using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class CpuDal : RepositoryBase<Cpu, EfContext>, ICpuDal
    {
        public Cpu get(int id)
        {
            using (EfContext context = new EfContext())
            {
                var cpu = context.Cpu.FirstOrDefault(x => x.id == id);
                return cpu;
            }
        }
    }
}
