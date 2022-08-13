using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class UpdatePersonelViewModel
    {
        public Personel personel { get; set; }
        public List<Sex> sex { get; set; }
        public List<Department> department { get; set; }
    }
}