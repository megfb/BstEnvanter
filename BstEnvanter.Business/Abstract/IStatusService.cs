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
    }
}
