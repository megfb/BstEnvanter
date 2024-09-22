using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface IServiceService
    {
        void add(Service entity);
        void remove(int id);
        void update(Service entity);
        Service get(int id);
        List<Service> getAll();
    }
}
