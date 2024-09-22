using BstEnvanter.WebUI.Identity;

namespace BstEnvanter.WebUI.Models
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
        }

        public ApplicationUser user { get; set; }
        public IList<string> role { get; internal set; }

    }
}