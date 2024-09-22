using BstEnvanter.Entity.Concrete;
using BstEnvanter.WebUI.Identity;

namespace BstEnvanter.WebUI.Models
{
    public class MoveToPersonelViewModel
    {

        public Status status { get; set; }
        public List<Personel> personel { get; set; }
        public List<Campus> campus { get; set; }
        public ApplicationUser user { get; internal set; }
    }
}