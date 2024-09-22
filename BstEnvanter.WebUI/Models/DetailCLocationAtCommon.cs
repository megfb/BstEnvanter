using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class DetailCLocationAtCommon
    {
        public DetailCLocationAtCommon()
        {
        }

        public List<Status> status { get; set; }
        public CLocation cLocation { get; internal set; }
    }
}