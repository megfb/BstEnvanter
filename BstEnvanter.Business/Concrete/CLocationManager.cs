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
    public class CLocationManager : ICLocationService
    {
        private ICLocationDal _cLocationDal;
        public CLocationManager(ICLocationDal cLocationDal)
        {
            _cLocationDal = cLocationDal;
        }
        public void add(CLocation entity)
        {
            _cLocationDal.add(entity);
        }

        public CLocation get(int id)
        {
            return _cLocationDal.getCLocation(id);
        }

        public List<CLocation> getAll()
        {
            return _cLocationDal.GetAll();
        }

        public void remove(int id)
        {
            _cLocationDal.remove(new CLocation { id = id });
        }

        public void update(CLocation entity)
        {
            _cLocationDal.update(entity);
        }
    }
}
