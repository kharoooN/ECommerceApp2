using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.WebUI.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

    }
}
