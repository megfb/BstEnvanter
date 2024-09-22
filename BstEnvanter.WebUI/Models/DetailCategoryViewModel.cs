using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class DetailCategoryViewModel
    {
        public DetailCategoryViewModel()
        {
        }

        public List<Status> status { get; set; }
        public int id { get; internal set; }
        public Category category { get; internal set; }
    }
}