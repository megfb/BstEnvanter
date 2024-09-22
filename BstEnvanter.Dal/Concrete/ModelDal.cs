using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class ModelDal : RepositoryBase<Model, EfContext>, IModelDal
    {
        public Model getModel(int id)
        {
            using (EfContext context = new EfContext())
            {
                var model = context.Model.FirstOrDefault(x => x.id == id);
                return model;

            }
        }
    }
}
