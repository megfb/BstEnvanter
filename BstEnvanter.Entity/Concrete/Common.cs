using BstEnvanter.Entity.Abstract;

namespace BstEnvanter.Entity.Concrete
{
    public class Common:IEntity
    {
        public int id { get; set; }
        public Department department { get; set; }
        public int departmentId { get; set; }
        public CLocation CLocation { get; set; }
        public int cLocationId { get; set; }
        public ICollection<Status> status { get; set; }
    }
}