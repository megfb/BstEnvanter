using BstEnvanter.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BstEnvanter.Entity.Concrete
{
    public class Status:IEntity
    {
        string _definition;
        public int id { get; set; }
        public Product Product { get; set; }
        public int productId { get; set; }
        public Personel Personel { get; set; }
        public int ?personelId { get; set; }
        public Common Common { get; set; }
        public int ?commonId { get; set; }
        public Campus Campus { get; set; }
        public int? campusId { get; set; }
        [Required(ErrorMessage ="Açıklama boş olamaz")]
        public string definition
        {
            get
            {
                if (_definition != null)
                {
                    return _definition = char.ToUpper(_definition.First()) + _definition.Substring(1).ToLower();
                }
                else
                {
                    return _definition;
                }
            }
            set { _definition = value.ToUpper(); }
        }
        public DateTime dateOfUpdate { get; set; }
        public string bstId { get; set; }
        public Service Service { get; set; }
        public int? serviceId { get; set; }
    }
}