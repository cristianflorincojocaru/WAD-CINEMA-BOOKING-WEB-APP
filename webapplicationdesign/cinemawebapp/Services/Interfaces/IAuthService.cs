using cinemawebapp.ViewModels;
using Microsoft.AspNetCore.Identity;
namespace cinemawebapp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterViewModel model);
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
        Task<bool> UpdateProfilePictureAsync(string userId, IFormFile file);
    }
}