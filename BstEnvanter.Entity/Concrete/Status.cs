using BstEnvanter.Entity.Abstract;

namespace BstEnvanter.Entity.Concrete
{
    public class Status:IEntity
    {
        public int id { get; set; }
        public Product Product { get; set; }
        public int productId { get; set; }
        public Personel Personel { get; set; }
        public int ?personelId { get; set; }
        public Common Common { get; set; }
        public int ?commonId { get; set; }
        public Campus Campus { get; set; }
        public int campusId { get; set; }
        public string definition { get; set; }
        public DateTime dateOfUpdate { get; set; }
        public string bstId { get; set; }
    }
}