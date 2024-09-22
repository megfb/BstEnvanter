using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class CommonDal : RepositoryBase<Common, EfContext>, ICommonDal
    {
        public Common getCommon(int id)
        {
            using (EfContext context = new EfContext())
            {
                return context.Common.FirstOrDefault(x => x.id == id);
            }
        }
    }
}
