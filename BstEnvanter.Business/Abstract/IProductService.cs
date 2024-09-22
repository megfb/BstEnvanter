using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface IProductService
    {
        void add(Product entity);
        void remove(int id);
        void update(Product entity);
        Product get(int id);
        List<Product> getAll();
        List<Product> getProductsAll();
        List<Product> getByCategory(int id);
    }
}
