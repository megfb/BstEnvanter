using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class CampusDal : RepositoryBase<Campus, EfContext>, ICampusDal
    {
        public Campus getCampus(int id)
        {
            using (EfContext context = new EfContext())
            {
                var campus = context.Campus.FirstOrDefault(x => x.id == id);
                return campus;
            }
        }
    }
}
