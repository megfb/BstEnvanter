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
    public class CampusManager : ICampusService
    {
        private ICampusDal _campusDal;
        public CampusManager(ICampusDal campusDal)
        {
            _campusDal = campusDal;
        }
        public void add(Campus entity)
        {
            _campusDal.add(entity);
        }

        public Campus get(int id)
        {
            return _campusDal.getCampus(id);
        }

        public List<Campus> getAll()
        {
            return _campusDal.GetAll();
        }


        public void remove(int id)
        {
            _campusDal.remove(new Campus { id = id });
        }

        public void update(Campus entity)
        {
            _campusDal.update(entity);
        }
    }
}
