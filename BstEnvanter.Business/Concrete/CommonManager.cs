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
    public class CommonManager : ICommonService
    {
        private ICommonDal _commonDal;
        public CommonManager(ICommonDal commonDal)
        {
            _commonDal = commonDal;
        }
        public void add(Common entity)
        {
            _commonDal.add(entity);
        }

        public Common get(int id)
        {
            return _commonDal.getCommon(id);
        }

        public List<Common> getAll()
        {
            return _commonDal.GetAll();
        }

        public void remove(int id)
        {
            _commonDal.remove(new Common { id = id });
        }

        public void update(Common entity)
        {
            _commonDal.update(entity);
        }
    }
}
