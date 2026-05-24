using cinemawebapp.Services.Interfaces;
using cinemawebapp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace cinemawebapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _auth;
        public AccountController(IAuthService auth) => _auth = auth;

        [HttpGet] public IActionResult Login() => View();
        [HttpGet] public IActionResult Register() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var result = await _auth.LoginAsync(model);
            if (result.Succeeded)
            {
                TempData["ToastSuccess"] = "Welcome back!";
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid email or password.");
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var result = await _auth.RegisterAsync(model);
            if (result.Succeeded)
            {
                TempData["ToastSuccess"] = "Account created! Welcome to The Film Vault.";
                return RedirectToAction("Index", "Home");
            }
            foreach (var e in result.Errors) ModelState.AddModelError("", e.Description);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _auth.LogoutAsync();
            TempData["ToastInfo"] = "You have been logged out.";
            return RedirectToAction("Index", "Home");
        }

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadProfilePicture(IFormFile file)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                await _auth.UpdateProfilePictureAsync(userId, file);
                TempData["ToastSuccess"] = "Profile picture updated!";
            }
            else
            {
                TempData["ToastError"] = "Could not update profile picture.";
            }
            return RedirectToAction("Index", "Profile");
        }
    }
}