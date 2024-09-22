using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class DetailGpuViewModel
    {
        public List<Status> status { get; set; }
        public Gpu gpu { get; set; }
    }
}