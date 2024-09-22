using BstEnvanter.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BstEnvanter.Entity.Concrete
{
    public class Brand:IEntity
    {
        string _name;
        public int id { get; set; }
        [Required(ErrorMessage ="Marka boş olamaz")]
        //[RegularExpression(@"[^\s]+",ErrorMessage ="Hatalı işlem, lütfen boşlukları kontrol ediniz")]
        public string name
        {
            get
            {
                if (_name !=null)
                {
                    return _name = char.ToUpper(_name.First()) + _name.Substring(1).ToLower();
                }
                else
                {
                    return _name;
                }
            }
            set { _name = value.ToUpper(); }
        }
        public ICollection<Product> product { get; set; }
    }
}