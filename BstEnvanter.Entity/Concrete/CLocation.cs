using BstEnvanter.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BstEnvanter.Entity.Concrete
{
    public class CLocation:IEntity
    {
        string _name;
        public int id { get; set; }
        [Required(ErrorMessage = "Lokasyon boş olamaz")]

        public string name
        {
            get
            {
                if (_name != null)
                {
                    return _name.ToUpper();
                }
                else
                {
                    return _name;
                }
            }
            set { _name = value.ToUpper(); }
        }
        public ICollection<Common> common { get; set; }
        public ICollection<Personel> personel { get; set; }
    }
}