using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BstEnvanter.WebUI.Identity
{
    public class ApplicationIdentityDbContext:IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options): base(options)
        {

        }
    }
}
