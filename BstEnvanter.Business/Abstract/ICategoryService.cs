using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface ICategoryService
    {
        void add(Category entity);
        void remove(int id);
        void update(Category entity);
        Category get(int id);
        List<Category> getAll();

    }
}
