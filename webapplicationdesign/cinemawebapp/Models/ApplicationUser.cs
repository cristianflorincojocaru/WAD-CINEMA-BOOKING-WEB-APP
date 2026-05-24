using Microsoft.AspNetCore.Identity;
namespace cinemawebapp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? ProfilePicturePath { get; set; }
    }
}