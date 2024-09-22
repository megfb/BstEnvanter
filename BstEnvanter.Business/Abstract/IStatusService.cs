using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface IStatusService
    {
        void add(Status entity);
        void remove(int id);
        void update(Status entity);
        Status get(int id);
        Status getStatus(int id);
        List<Status> getAll();
        List<Status> getAllWithDetails();
        List<Status> getAllWithDetailsByCategory(int id);
        List<Status> getAllWithDetailsByBrand(int id);
        List<Status> getAllWithDetailsByModel(int id);
        List<Status> getAllWithDetailsByCampus(int id);
        List<Status> getAllWithDetailsByDepartmentAtCommon(int id);
        List<Status> getAllWithDetailsByDepartmentAtPersonel(int id);
        List<Status> getAllWithDetailsByCLocationAtCommon(int id);
        List<Status> getAllWithDetailsByPersonel(int id);
        List<Status> getAllWithDetailsByCpu(int id);
        List<Status> getAllWithDetailsByGpu(int id);
        List<Status> getAllWithDetailsByRam(int id);
        List<Status> getAllWithDetailsByHardDrive(int id);
        List<Status> getAllWithDetailsByService(int id);
        List<Status> getAllWithDetailsByCLocationAtPersonel(int id);
    }
}
