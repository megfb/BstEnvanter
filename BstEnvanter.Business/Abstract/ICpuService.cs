using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface ICpuService
    {
        void add(Cpu entity);
        void remove(int id);
        void update(Cpu entity);
        Cpu get(int id);
        List<Cpu> getAll();
    }
}
