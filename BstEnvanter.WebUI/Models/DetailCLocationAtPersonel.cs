using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class DetailCLocationAtPersonel
    {
        public DetailCLocationAtPersonel()
        {
        }

        public List<Status> status { get; set; }
        public CLocation cLocation { get; set; }
    }
}