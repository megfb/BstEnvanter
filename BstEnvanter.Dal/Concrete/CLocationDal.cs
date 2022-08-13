using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class CLocationDal : RepositoryBase<CLocation, EfContext>, ICLocationDal
    {
        public CLocation getCLocation(int id)
        {
            using (EfContext context = new EfContext())
            {
                var cLocation = context.CLocation.FirstOrDefault(x => x.id == id);
                return cLocation;
            }
        }
    }
}
