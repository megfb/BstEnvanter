using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class AddProductAtCommonViewModel
    {
        public Status status { get; internal set; }
        public Common common { get; internal set; }
        public List<Campus> campus { get; internal set; }
    }
}