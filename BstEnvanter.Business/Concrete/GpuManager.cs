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
    public class GpuManager : IGpuService
    {
        private IGpuDal _gpuDal;
        public GpuManager(IGpuDal gpuDal)
        {
            _gpuDal = gpuDal;
        }
        public void add(Gpu entity)
        {
            _gpuDal.add(entity);
        }

        public Gpu get(int id)
        {
            return _gpuDal.getGpu(id);
        }

        public List<Gpu> getAll()
        {
            return _gpuDal.GetAll();
        }

        public void remove(int id)
        {
            _gpuDal.remove(new Gpu { id = id });
        }

        public void update(Gpu entity)
        {
            _gpuDal.update(entity);
        }
    }
}
