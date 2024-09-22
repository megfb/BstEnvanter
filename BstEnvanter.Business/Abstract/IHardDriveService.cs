using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface IHardDriveService
    {
        void add(HardDrive entity);
        void remove(int id);
        void update(HardDrive entity);
        HardDrive get(int id);
        List<HardDrive> getAll();
    }
}
