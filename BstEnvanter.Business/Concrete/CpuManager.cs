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
    public class CpuManager : ICpuService
    {
        private ICpuDal _CpuDal;
        public CpuManager(ICpuDal cpuDal)
        {
            _CpuDal = cpuDal;
        }
        public void add(Cpu entity)
        {
            _CpuDal.add(entity);
        }

        public Cpu get(int id)
        {
            return _CpuDal.get(id);
        }

        public List<Cpu> getAll()
        {
            return _CpuDal.GetAll();
        }

        public void remove(int id)
        {
            _CpuDal.remove(new Cpu { id = id });
        }

        public void update(Cpu entity)
        {
            _CpuDal.update(entity);
        }
    }
}
