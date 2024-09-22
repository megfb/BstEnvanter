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

        public List<Status> getAllWithDetailsByBrand(int id)
        {
            return _statusDal.getStatusAllWithDetails(p => p.Product.brandId == id || id == 0);
        }

        public List<Status> getAllWithDetailsByCampus(int id)
        {
            return _statusDal.getStatusAllWithDetails(p => p.campusId == id || id == 0);
        }

        public List<Status> getAllWithDetailsByCategory(int id)
        {
            return _statusDal.getStatusAllWithDetails(p => p.Product.categoryId == id || id == 0);
        }

        public List<Status> getAllWithDetailsByCLocationAtCommon(int id)
        {
            return _statusDal.getStatusAllWithDetails(p => p.Common.cLocationId == id || id == 0);
        }

        public List<Status> getAllWithDetailsByCLocationAtPersonel(int id)
        {
            return _statusDal.getStatusAllWithDetails(p => p.Personel.cLocationId == id || id == 0);
        }

        public List<Status> getAllWithDetailsByCpu(int id)
        {
            return _statusDal.getStatusAllWithDetails(p => p.Product.cpuId == id || id == 0);
        }

        public List<Status> getAllWithDetailsByDepartmentAtCommon(int id)
        {
            return _statusDal.getStatusAllWithDetails(p => p.Common.departmentId == id || id == 0);
        }
        public List<Status> getAllWithDetailsByDepartmentAtPersonel(int id)
        {
            return _statusDal.getStatusAllWithDetails(p => p.Personel.departmentId == id || id == 0);
        }

        public List<Status> getAllWithDetailsByGpu(int id)
        {
            return _statusDal.getStatusAllWithDetails(p => p.Product.gpuId == id || id == 0);
        }

        public List<Status> getAllWithDetailsByHardDrive(int id)
        {
            return _statusDal.getStatusAllWithDetails(p => p.Product.hardDriveId == id || id == 0);
        }

        public List<Status> getAllWithDetailsByModel(int id)
        {
            return _statusDal.getStatusAllWithDetails(p => p.Product.modelId == id || id == 0);
        }

        public List<Status> getAllWithDetailsByPersonel(int id)
        {
            return _statusDal.getStatusAllWithDetails(p => p.personelId == id || id == 0);
        }

        public List<Status> getAllWithDetailsByRam(int id)
        {
            return _statusDal.getStatusAllWithDetails(p => p.Product.ramId == id || id == 0);
        }

        public List<Status> getAllWithDetailsByService(int id)
        {
            return _statusDal.getStatusAllWithDetails(x => x.Product.categoryId == id || id == 0 & x.serviceId != null);
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
