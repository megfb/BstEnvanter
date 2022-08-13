using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Abstract
{
    public interface IProductDal : IRepositoryBase<Product>
    {

        List<Product> GetProductsAll(Expression<Func<Product, bool>> filter = null);
        Product getProduct(int id);
    }
}
