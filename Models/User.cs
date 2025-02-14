using Microsoft.AspNetCore.Identity;

namespace C_Scherp_Api.Models
{
    public class User : IdentityUser
    {
        // Add custom properties if needed
        public string? FullName { get; set; }
    }
}