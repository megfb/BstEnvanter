using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class DetailCampusModel
    {
        public DetailCampusModel()
        {
        }

        public List<Status> status { get; set; }
        public Campus campus { get; set; }
    }
}