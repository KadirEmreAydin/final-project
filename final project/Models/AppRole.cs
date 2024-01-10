using Microsoft.AspNetCore.Identity;

namespace final_project.Models
{
    public class AppRole : IdentityRole
    {
        public string FullName { get; set; }
        public string City { get; set; }
    }
}
