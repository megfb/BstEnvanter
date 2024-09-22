using BstEnvanter.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BstEnvanter.Entity.Concrete
{
    public class Product : IEntity
    {
        string _name;
        public int id { get; set; }
        public Category Category { get; set; }
        public int? categoryId { get; set; }
        public Brand Brand { get; set; }
        public int? brandId { get; set; }
        public Model Model { get; set; }
        public int? modelId { get; set; }
        [Required(ErrorMessage = "Ürün adı boş olamaz")]
        public string name
        {
            get
            {
                if (_name != null)
                {
                    return _name = char.ToUpper(_name.First()) + _name.Substring(1).ToLower();
                }
                else
                {
                    return _name;
                }
            }
            set { _name = value.ToUpper(); }
        }
        [Required(ErrorMessage = "Seri numarası boş olamaz")]
        public string serialNo { get; set; }
        [Required(ErrorMessage = "Envanter numarası boş olamaz")]
        public string inventoryNo { get; set; }
        public Cpu Cpu { get; set; }
        public int? cpuId { get; set; }
        public Gpu Gpu { get; set; }
        public int? gpuId { get; set; }
        public Ram Ram { get; set; }
        public int? ramId { get; set; }
        public HardDrive HardDrive { get; set; }
        public int? hardDriveId { get; set; }
        public string? imgName { get; set; }
        public ICollection<Status> status { get; set; }



    }
}
