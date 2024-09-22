using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class DetailPersonelViewModel
    {
        public Personel personel { get; set; }
        public List<Status> status { get; internal set; }
    }
}