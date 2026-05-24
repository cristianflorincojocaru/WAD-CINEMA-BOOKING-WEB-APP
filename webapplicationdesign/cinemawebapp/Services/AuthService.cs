using cinemawebapp.Models;
using cinemawebapp.Services.Interfaces;
using cinemawebapp.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace cinemawebapp.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _env;

        public AuthService(UserManager<ApplicationUser> um, SignInManager<ApplicationUser> sm, IWebHostEnvironment env)
        {
            _userManager = um; _signInManager = sm; _env = env;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user, false);
            }
            return result;
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model) =>
            await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

        public async Task LogoutAsync() => await _signInManager.SignOutAsync();

        public async Task<bool> UpdateProfilePictureAsync(string userId, IFormFile file)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null || file == null || file.Length == 0) return false;

            var dir = Path.Combine(_env.WebRootPath, "uploads", "profiles");
            Directory.CreateDirectory(dir);

            // Șterge poza veche
            if (!string.IsNullOrEmpty(user.ProfilePicturePath))
            {
                var oldPath = Path.Combine(_env.WebRootPath, user.ProfilePicturePath.TrimStart('/'));
                if (System.IO.File.Exists(oldPath)) System.IO.File.Delete(oldPath);
            }

            var fileName = $"{userId}_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}{Path.GetExtension(file.FileName)}";
            using var stream = new FileStream(Path.Combine(dir, fileName), FileMode.Create);
            await file.CopyToAsync(stream);

            user.ProfilePicturePath = $"/uploads/profiles/{fileName}";
            await _userManager.UpdateAsync(user);
            return true;
        }
    }
}