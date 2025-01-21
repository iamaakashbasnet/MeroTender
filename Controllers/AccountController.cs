using System.Security.Claims;
using MeroTender.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MeroTender.Models;

namespace MeroTender.Controllers
{
    [Authorize]
    public class AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
        : Controller
    {
        [AllowAnonymous]
        public IActionResult SignUp() => View(new UserSignupModel());

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signup(UserSignupModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var existingUser = await userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Email already exists.");
                return View(request);
            }

            // Use ApplicationUser instead of IdentityUser
            var user = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email,
                EmailConfirmed = true,
                // Add any additional custom properties here
            };

            var createResult = await userManager.CreateAsync(user, request.Password);
            if (!createResult.Succeeded)
            {
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(request);
            }

            TempData["SuccessMessage"] = "Signup successful, now you can login!";
            return RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login() => View(new UserLoginModel());

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            // Find the user by email or username
            var user = await userManager.FindByEmailAsync(request.EmailOrUsername)
                       ?? await userManager.FindByNameAsync(request.EmailOrUsername);

            if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
            {
                ModelState.AddModelError("message", "Invalid credentials");
                return View(request);
            }

            // Check if the email is confirmed
            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError("message", "Email not confirmed yet");
                return View(request);
            }

            // Attempt to sign in with the user's username (email won't work for PasswordSignInAsync)
            var signInResult = await signInManager.PasswordSignInAsync(user, request.Password, true, true);

            if (!signInResult.Succeeded)
            {
                if (signInResult.IsLockedOut)
                {
                    return View("AccountLocked");
                }

                ModelState.AddModelError("message", "Invalid login attempt");
                return View(request);
            }

            // Add a custom claim, if required
            await userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));

            return RedirectToAction("Dashboard");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccountLocked() => View();

        [HttpGet]
        [Authorize]
        public IActionResult Dashboard() => View();
    }
}
