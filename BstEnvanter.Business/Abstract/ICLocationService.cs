using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface ICLocationService
    {
        void add(CLocation entity);
        void remove(int id);
        void update(CLocation entity);
        CLocation get(int id);
        List<CLocation> getAll();
    }
}
