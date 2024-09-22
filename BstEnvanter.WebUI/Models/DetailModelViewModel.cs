using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class DetailModelViewModel
    {
        public DetailModelViewModel()
        {
        }

        public List<Status> status { get; set; }
        public Model model { get; set; }
    }
}