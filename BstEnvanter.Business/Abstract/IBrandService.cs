using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface IBrandService
    {
        void add(Brand entity);
        void remove(int id);
        void update(Brand entity);
        Brand get(int id);
        List<Brand> getAll();
    }
}
