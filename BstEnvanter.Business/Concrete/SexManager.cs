
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
    public class SexManager : ISexService
    {
        private ISexDal _sexDal;
        public SexManager(ISexDal sexDal)
        {
            _sexDal = sexDal;
        }
        public void add(Sex entity)
        {
            _sexDal.add(entity);
        }

        public Sex get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Sex> getAll()
        {
            return _sexDal.GetAll();
        }
        public void remove(Sex entity)
        {
            _sexDal.remove(entity);
        }

        public void update(Sex entity)
        {
            _sexDal.update(entity);
        }
    }
}
