using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface IModelService
    {
        void add(Model entity);
        void remove(int id);
        void update(Model entity);
        Model get(int id);
        List<Model> getAll();
    }
}
