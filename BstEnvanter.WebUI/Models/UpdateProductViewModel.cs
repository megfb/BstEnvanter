using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class UpdateProductViewModel
    {

        public List<Category> category { get; set; }
        public List<Brand> brand { get; set; }
        public List<Model> model { get; set; }
        public Status status { get; internal set; }
        public Product product { get; internal set; }
    }
}