using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class ListOfProductAtServiceViewModel
    {
        public List<Status> status { get; internal set; }
        public List<Category> category { get; internal set; }
        public int categoryId { get; internal set; }
    }
}