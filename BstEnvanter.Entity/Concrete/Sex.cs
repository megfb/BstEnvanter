using BstEnvanter.Entity.Abstract;

namespace BstEnvanter.Entity.Concrete
{
    public class Sex:IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Personel> personel { get; set; }
    }
}