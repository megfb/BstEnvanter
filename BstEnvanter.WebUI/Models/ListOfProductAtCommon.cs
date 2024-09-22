using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class ListOfProductAtCommon
    {
        public List<Status> status { get; set; }
        public List<Category> category { get; internal set; }
        public int categoryId { get; internal set; }
    }
}