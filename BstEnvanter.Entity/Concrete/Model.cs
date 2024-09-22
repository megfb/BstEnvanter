using BstEnvanter.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BstEnvanter.Entity.Concrete
{
    public class Model:IEntity
    {
        string _name;
        public int id { get; set; }
        [Required(ErrorMessage = "Model boş olamaz")]

        public string name
        {
            get
            {
                if (_name != null)
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