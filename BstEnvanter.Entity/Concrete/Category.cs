using BstEnvanter.Entity.Abstract;

namespace BstEnvanter.Entity.Concrete
{
    public class Category:IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Product> product { get; set; }
    }
}