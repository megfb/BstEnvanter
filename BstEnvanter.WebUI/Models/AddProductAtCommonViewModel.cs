using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class AddProductAtCommonViewModel
    {
        public Status status { get; internal set; }
        public Common common { get; internal set; }
        public List<Campus> campus { get; internal set; }
        public List<CLocation> cLocation { get; internal set; }
        public List<Department> department { get; internal set; }
        public int commonId { get; internal set; }
    }
}