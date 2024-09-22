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
    public class RamManager:IRamService
    {
        private IRamDal _ramDal;
        public RamManager(IRamDal ramDal)
        {
            _ramDal = ramDal;
        }

        public void add(Ram entity)
        {
            _ramDal.add(entity);
        }

        public Ram get(int id)
        {
            return _ramDal.getRam(id);
        }

        public List<Ram> getAll()
        {
            return _ramDal.GetAll();
        }

        public void remove(int id)
        {
            _ramDal.remove(new Ram { id = id });
        }

        public void update(Ram entity)
        {
            _ramDal.update(entity);
        }
    }
}
