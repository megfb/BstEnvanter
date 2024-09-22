using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class ListOfProductAtPersonelViewModel
    {
        public ListOfProductAtPersonelViewModel()
        {
        }

        public List<Status> product { get; set; }
        public List<Category> category { get; internal set; }
        public int categoryId { get; internal set; }
    }
}