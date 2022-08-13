using BstEnvanter.Entity.Abstract;

namespace BstEnvanter.Entity.Concrete
{
    public class Personel:IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public Sex Sex { get; set; }
        public int sexId { get; set; }
        public Department Department { get; set; }
        public int departmentId { get; set; }
        public string roomNo { get; set; }
        public ICollection<Status> status { get; set; }
    }
}