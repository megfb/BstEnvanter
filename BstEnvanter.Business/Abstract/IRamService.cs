using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface IRamService
    {
        void add(Ram entity);
        void remove(int id);
        void update(Ram entity);
        Ram get(int id);
        List<Ram> getAll();
    }
}
