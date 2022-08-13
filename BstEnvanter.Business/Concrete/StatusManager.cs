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
    public class StatusManager : IStatusService
    {
        private IStatusDal _statusDal;
        public StatusManager(IStatusDal statusDal)
        {
            _statusDal = statusDal;
        }
        public void add(Status entity)
        {
            _statusDal.add(entity);
        }

        public Status get(int id)
        {
            return _statusDal.getStatusWithDetail(id);
        }

        public List<Status> getAll()
        {
            return _statusDal.GetAll();
        }

        public List<Status> getAllWithDetails()
        {
            return _statusDal.getStatusAllWithDetails();
        }

        public Status getStatus(int id)
        {
            return _statusDal.getStatus(id);
        }

        public void remove(int id)
        {
            _statusDal.remove(new Status { id = id });
        }

        public void update(Status entity)
        {
            _statusDal.update(entity);
        }
    }
}
