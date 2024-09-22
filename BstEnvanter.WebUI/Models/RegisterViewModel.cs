using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace BstEnvanter.WebUI.Models
{
    public class RegisterViewModel
    {
        public string userName { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        [DataType(DataType.Password)]
        public string rePassword { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string department { get; set; }
        public string roomNo { get; set; }
        public string title { get; set; }
        public string role { get; set; }

    }
}
