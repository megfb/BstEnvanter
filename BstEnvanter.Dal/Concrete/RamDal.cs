using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class RamDal : RepositoryBase<Ram, EfContext>, IRamDal
    {
        public Ram getRam(int id)
        {
            using (EfContext context = new EfContext())
            {
                var ram = context.Ram.FirstOrDefault(x => x.id == id);
                return ram;
            }
        }
    }
}
