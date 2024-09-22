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
    public class HardDriveManager:IHardDriveService
    {
        private IHardDriveDal _hardDriveDal;
        public HardDriveManager(IHardDriveDal hardDriveDal)
        {
            _hardDriveDal = hardDriveDal;
        }

        public void add(HardDrive entity)
        {
            _hardDriveDal.add(entity);
        }

        public HardDrive get(int id)
        {
            return _hardDriveDal.getHardDrive(id);
        }

        public List<HardDrive> getAll()
        {
            return _hardDriveDal.GetAll();
        }

        public void remove(int id)
        {
            _hardDriveDal.remove(new HardDrive { id = id });
        }

        public void update(HardDrive entity)
        {
            _hardDriveDal.update(entity);
        }
    }
}
