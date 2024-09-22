using BstEnvanter.Business.Abstract;
using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void add(Product entity)
        {
            _productDal.add(entity);
        }

        public Product get(int id)
        {
            return _productDal.getProduct(id);
        }

        public List<Product> getAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> getByCategory(int id)
        {
            return _productDal.GetProductsAll(x => x.categoryId == id || id == 0);
        }

        public List<Product> getProductsAll()
        {
            return _productDal.GetProductsAll();
        }

        public void remove(int id)
        {
            _productDal.remove(new Product { id = id});
        }

        public void update(Product entity)
        {
            _productDal.update(entity);
        }
    }
}
