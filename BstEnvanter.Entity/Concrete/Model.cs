using BstEnvanter.Entity.Abstract;

namespace BstEnvanter.Entity.Concrete
{
    public class Model:IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Product> product { get; set; }
    }
}