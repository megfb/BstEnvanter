using BstEnvanter.WebUI.Identity;

namespace BstEnvanter.WebUI.Models
{
    public class ListOfUserViewModel
    {
        public ListOfUserViewModel()
        {
        }

        public IQueryable<ApplicationUser> users { get; set; }
    }
}