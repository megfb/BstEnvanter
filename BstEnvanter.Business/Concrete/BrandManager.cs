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
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void add(Brand entity)
        {
            _brandDal.add(entity);
        }

        public Brand get(int id)
        {
            return _brandDal.getBrand(id);
        }

        public List<Brand> getAll()
        {
            return _brandDal.GetAll();
        }

        public void remove(int id)
        {
            _brandDal.remove(new Brand { id = id});
        }

        public void update(Brand entity)
        {
            _brandDal.update(entity);
        }
    }
}
