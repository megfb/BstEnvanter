using BstEnvanter.WebUI.Identity;

namespace BstEnvanter.WebUI.Models
{
    public class ResetUserPasswordViewModel
    {
        public ResetUserPasswordViewModel()
        {
        }

        public string newPassword { get; set; }
        public string id { get; internal set; }
    }
}