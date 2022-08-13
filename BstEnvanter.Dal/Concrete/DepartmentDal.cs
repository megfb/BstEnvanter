using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class DepartmentDal : RepositoryBase<Department, EfContext>, IDepartmentDal
    {
        public Department getDepartment(int id)
        {
            using(EfContext context = new EfContext())
            {
                var department = context.Department.FirstOrDefault(x => x.id == id);
                return department;
            }
        }
    }
}
