using BstEnvanter.Entity.Abstract;

namespace BstEnvanter.Entity.Concrete
{
    public class Campus:IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Status> status { get; set; }

    }
}