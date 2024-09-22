using BstEnvanter.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Entity.Concrete
{
    public class Chart:IEntity
    {
        public string dimension { get; set; }
        public int quantity { get; set; }
    }
}
