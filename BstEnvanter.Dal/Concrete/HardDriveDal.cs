using BstEnvanter.Dal.Abstract;
using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class HardDriveDal : RepositoryBase<HardDrive, EfContext>, IHardDriveDal
    {
        public HardDrive getHardDrive(int id)
        {
            using (EfContext context = new EfContext())
            {
                var hardDrive = context.HardDrive.FirstOrDefault(x => x.id == id);
                return hardDrive;
            }
        }
    }
}
