using BstEnvanter.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Entity.Concrete
{
    public class Product:IEntity
    {
        public int id { get; set; }
        public Category Category { get; set; }
        public int categoryId { get; set; }
        public Brand Brand { get; set; }
        public int brandId { get; set; }
        public Model Model { get; set; }
        public int modelId { get; set; }
        public string name { get; set; }
        public string serialNo { get; set; }
        public string inventoryNo { get; set; }
        public string ?prop1 { get; set; }
        public string ?prop2 { get; set; }
        public string ?prop3 { get; set; }
        public string ?prop4 { get; set; }
        public ICollection<Status> status { get; set; }

    }
}
