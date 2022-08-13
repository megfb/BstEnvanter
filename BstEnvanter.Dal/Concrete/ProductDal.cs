using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class ProductDal : RepositoryBase<Product, EfContext>, IProductDal
    {
        public Product getProduct(int id)
        {
            using (EfContext context = new EfContext())
            {
                var product = context.Product.Include(x => x.Category).Include(x => x.Brand).Include(x => x.Model).FirstOrDefault(x => x.id == id);
                return product;
            }
        }

        public List<Product> GetProductsAll(Expression<Func<Product, bool>> filter = null)
        {
            using (var context = new EfContext())
            {
                return filter == null ?
                    context.Set<Product>().Include(b => b.Category).Include(x => x.Model)
                    .Include(b => b.Brand).ToList() :
                    context.Set<Product>().Include(b => b.Category).Include(x => x.Model)
                    .Include(b => b.Brand).Where(filter).ToList();
            }
        }
    }
}
