using System.ComponentModel.DataAnnotations;

namespace BstEnvanter.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-Mail boş olamaz")]
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }
        [Required(ErrorMessage = "Parola boş olamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}