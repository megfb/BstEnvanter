using Microsoft.AspNetCore.Identity;

namespace BstEnvanter.WebUI.Identity
{
    public class CustomPasswordValidator: PasswordValidator<ApplicationUser>
    {
        public override bool IsLower(char c)
        {
            if (c == 'ğ' || c == 'ü' || c == 'ş' || c == 'ı' || c == 'ş' || c == 'ö' || c == 'ç')
                return true;
            else if (c >= 'a' && c <= 'z')
                return true;
            else
                return false;
        }
        public override bool IsUpper(char c)
        {
            if (c == 'Ğ' || c == 'Ü' || c == 'Ş' || c == 'İ' || c == 'Ş' || c == 'Ö' || c == 'Ç')
                return true;
            else if (c >= 'A' && c <= 'Z')
                return true;
            else
                return false;
        }
    }
}
