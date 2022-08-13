
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
    public class PersonelManager : IPersonelService
    {
        private IPersonelDal _personelDal;
        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }

        public void add(Personel entity)
        {
            _personelDal.add(entity);
        }

        public Personel get(int id)
        {
            return _personelDal.getPersonelWithDetail(id);
        }

        public List<Personel> getAll()
        {
            return _personelDal.GetAll();
        }


        public void remove(int id)
        {
            _personelDal.remove(new Personel { id = id });
        }

        public void update(Personel entity)
        {
            _personelDal.update(entity);
        }
    }
}
