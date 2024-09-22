using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface ISexService
    {
        void add(Sex entity);
        void remove(Sex entity);
        void update(Sex entity);
        Sex get(int id);
        List<Sex> getAll();
    }
}
