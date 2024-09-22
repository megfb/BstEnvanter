using System.ComponentModel.DataAnnotations;

namespace BstEnvanter.WebUI.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Cannot be null")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Cannot be null")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
    }
}