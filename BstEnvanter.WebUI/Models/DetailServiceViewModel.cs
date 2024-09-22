using BstEnvanter.Entity.Concrete;
using BstEnvanter.WebUI.Identity;

namespace BstEnvanter.WebUI.Models
{
    public class DetailServiceViewModel
    {

        public Status status { get; set; }
        public ApplicationUser user { get; internal set; }
    }
}