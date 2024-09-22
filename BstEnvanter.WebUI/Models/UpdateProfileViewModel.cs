using BstEnvanter.WebUI.Identity;
using System.Security.Claims;

namespace BstEnvanter.WebUI.Models
{
    public class UpdateProfileViewModel
    {
        public ApplicationUser user { get; internal set; }
    }
}