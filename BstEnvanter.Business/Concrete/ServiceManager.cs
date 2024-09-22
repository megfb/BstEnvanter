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
    public class ServiceManager : IServiceService
    {
        public IServiceDal _serviceDal;
        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }
        public void add(Service entity)
        {
            _serviceDal.add(entity);
        }

        public Service get(int id)
        {
            return _serviceDal.getService(id);
        }

        public List<Service> getAll()
        {

            return _serviceDal.GetAll();
        }

        public void remove(int id)
        {
            _serviceDal.remove(new Service { id = id});
        }

        public void update(Service entity)
        {
            _serviceDal.update(entity);
        }
    }
}
