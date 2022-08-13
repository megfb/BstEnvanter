using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class PersonelDal : RepositoryBase<Personel, EfContext>, IPersonelDal
    {
        public Personel getPersonelWithDetail(int id)
        {
            using (EfContext context = new EfContext())
            {
                var personel = context.Personel.Include(x => x.Department).Include(x => x.Sex).FirstOrDefault(x => x.id == id);
                return personel;
            }
        }
    }
}
