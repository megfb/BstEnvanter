using BstEnvanter.Entity.Concrete;
using BstEnvanter.WebUI.Identity;

namespace BstEnvanter.WebUI.Models
{
    public class UpdateServiceViewModel
    {
        public UpdateServiceViewModel()
        {
        }

        public Status status { get; set; }
        public ApplicationUser user { get; internal set; }
    }
}