using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class BrandDal : RepositoryBase<Brand, EfContext>, IBrandDal
    {
        public Brand getBrand(int id)
        {
            using(EfContext context = new EfContext())
            {
                var brand = context.Brand.FirstOrDefault(x => x.id == id);
                return brand;
            }
        }
    }
}
