using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class AddProductViewModel2
    {
        public Status status { get; set; }
        public string name { get; set; }

        public List<Category> category { get; set; }
        public List<Brand> brand { get; set; }
        public List<Model> model { get; set; }
        public List<Campus> campus { get; set; }
        public List<Cpu> cpu { get; internal set; }
        public List<Gpu> gpu { get; internal set; }
        public List<Ram> ram { get; internal set; }
        public List<HardDrive> hardDrive { get; internal set; }
    }
}
