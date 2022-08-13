using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface ICampusService
    {
        void add(Campus entity);
        void remove(int id);
        void update(Campus entity);
        Campus get(int id);
        List<Campus> getAll();

    }
}
