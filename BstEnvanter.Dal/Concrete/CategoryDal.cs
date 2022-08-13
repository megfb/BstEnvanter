using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class CategoryDal : RepositoryBase<Category, EfContext>, ICategoryDal
    {
        public Category getCategory(int id)
        {
            using (EfContext context = new EfContext())
            {
                var category = context.Category.FirstOrDefault(x => x.id == id);
                return category;
            }
        }
    }
}
