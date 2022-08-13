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
    public class DepartmentManager : IDepartmentService
    {
        private IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public void add(Department entity)
        {
            _departmentDal.add(entity);
        }

        public Department get(int id)
        {
            return _departmentDal.getDepartment(id);
        }

        public List<Department> getAll()
        {
            return _departmentDal.GetAll();
        }

        public void remove(int id)
        {
            _departmentDal.remove(new Department { id = id});
        }

        public void update(Department entity)
        {
            _departmentDal.update(entity);
        }
    }
}
