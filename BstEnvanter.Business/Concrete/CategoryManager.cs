
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
    public class CategoryManager:ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void add(Category entity)
        {
            _categoryDal.add(entity);
        }

        public Category get(int id)
        {
            return _categoryDal.getCategory(id);
        }

        public List<Category> getAll()
        {
            return _categoryDal.GetAll();
        }

        public void remove(int id)
        {
            _categoryDal.remove(new Category{ id = id });
        }

        public void update(Category entity)
        {
            _categoryDal.update(entity);
        }
    }
}
