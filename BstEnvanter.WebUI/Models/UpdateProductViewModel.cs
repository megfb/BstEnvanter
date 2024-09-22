using BstEnvanter.Entity.Concrete;
using BstEnvanter.WebUI.Identity;

namespace BstEnvanter.WebUI.Models
{
    public class UpdateProductViewModel
    {
        public List<Category> category { get; set; }
        public List<Brand> brand { get; set; }
        public List<Model> model { get; set; }
        public Status status { get; internal set; }
        public Product product { get; internal set; }
        public List<Cpu> cpu { get; internal set; }
        public List<Ram> ram { get; internal set; }
        public List<HardDrive> hardDrive { get; internal set; }
        public List<Gpu> gpu { get; internal set; }
        public ApplicationUser user { get; set; }
        public List<Campus> campus { get; internal set; }
        public IFormFile formFile { get; set; }

    }
}