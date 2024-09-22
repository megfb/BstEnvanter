using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface IGpuService
    {
        void add(Gpu entity);
        void remove(int id);
        void update(Gpu entity);
        Gpu get(int id);
        List<Gpu> getAll();
    }
}
