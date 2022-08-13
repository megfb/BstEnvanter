using BstEnvanter.Entity.Abstract;

namespace BstEnvanter.Entity.Concrete
{
    public class CLocation:IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Common> common { get; set; }
    }
}