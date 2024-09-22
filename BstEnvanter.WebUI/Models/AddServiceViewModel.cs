using BstEnvanter.Entity.Concrete;
using BstEnvanter.WebUI.Identity;

namespace BstEnvanter.WebUI.Models
{
    public class AddServiceViewModel
    {
        public Status status { get; set; }
        public Service service { get; set; }
        public ApplicationUser user { get; internal set; }
    }
}