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
    public class ModelManager : IModelService
    {
        private IModelDal _modelDal;
        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }
        public void add(Model entity)
        {
            _modelDal.add(entity);
        }

        public Model get(int id)
        {
            return _modelDal.getModel(id);
        }

        public List<Model> getAll()
        {
            return _modelDal.GetAll();
        }

        public void remove(int id)
        {
            _modelDal.remove(new Model { id = id });
        }

        public void update(Model entity)
        {
            _modelDal.update(entity);
        }
    }
}
