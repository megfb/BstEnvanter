using BstEnvanter.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Business.Abstract
{
    public interface IPersonelService
    {
        void add(Personel entity);
        void remove(int id);
        void update(Personel entity);
        Personel get(int id);
        List<Personel> getAll();
    }
}
