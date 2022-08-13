using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class AddCommonViewModel
    {
        public AddCommonViewModel()
        {
        }

        public Common common { get; set; }
        public List<Department> department { get; set; }
        public List<CLocation> clocation { get; set; }
        public int id { get; set; }
    }
}