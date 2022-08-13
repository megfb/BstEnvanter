using BstEnvanter.Entity.Abstract;

namespace BstEnvanter.Entity.Concrete
{
    public class Department:IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Personel> personel { get; set; }
        public ICollection<Common> common { get; set; }
    }
}