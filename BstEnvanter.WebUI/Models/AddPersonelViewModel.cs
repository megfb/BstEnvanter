using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class AddPersonelViewModel
    {
        public AddPersonelViewModel()
        {
        }

        public Personel personel { get; set; }
        public List<Sex> sex { get; set; }
        public List<Department> deparment { get; set; }
        public List<CLocation> cLocation { get; internal set; }
    }
}