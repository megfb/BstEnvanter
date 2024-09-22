using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class DetailHardDriveViewModel
    {
        public DetailHardDriveViewModel()
        {
        }

        public List<Status> status { get; set; }
        public HardDrive hardDrive { get; internal set; }
    }
}