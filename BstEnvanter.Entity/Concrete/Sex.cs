using BstEnvanter.Entity.Abstract;
using System.Xml.Linq;

namespace BstEnvanter.Entity.Concrete
{
    public class Sex:IEntity
    {
        string _name;
        public int id { get; set; }
        public string name
        {
            get { return _name = char.ToUpper(_name.First()) + _name.Substring(1).ToLower(); }
            set { _name = value.ToUpper(); }
        }
        public ICollection<Personel> personel { get; set; }
    }
}