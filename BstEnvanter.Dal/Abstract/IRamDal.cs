using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Abstract
{
    public interface IRamDal: IRepositoryBase<Ram>
    {
        Ram getRam(int id);
    }
}
