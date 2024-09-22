using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface ICommonService
    {
        void add(Common entity);
        void remove(int id);
        void update(Common entity);
        Common get(int id);
        List<Common> getAll();


    }
}
