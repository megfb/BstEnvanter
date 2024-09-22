using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface IDepartmentService
    {
        void add(Department entity);
        void remove(int id);
        void update(Department entity);
        Department get(int id);
        List<Department> getAll();

    }
}
