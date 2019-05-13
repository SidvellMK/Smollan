using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DataAccess.Models;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using LoginWebApp.Models.ViewModels;
using System.Linq;

namespace LoginWebApp.Controllers
{
    public class LoginController : Controller
    {
        private IConfiguration _configuration;
        private DataContext _dataContext;

        public LoginController(IConfiguration configuration, DataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        public IActionResult Login()
        {
            return View(new Login());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email, Password")] Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var loginApiUrl = _configuration.GetSection("ApiUrls").GetSection("LoginApi").Value;

                    client.BaseAddress = new Uri(loginApiUrl);

                    var postTask = client.PostAsJsonAsync<Login>("Users/Authenticate", login);
                    postTask.Wait();

                    var result = postTask.Result;                 

                    if (result.IsSuccessStatusCode)
                    {
                        var requestTask = client.GetAsync("Users");
                        requestTask.Wait();

                        var response = requestTask.Result;

                        var readTask = response.Content.ReadAsAsync<IList<UserViewModel>>();
                        readTask.Wait();

                        var users = readTask.Result ?? Enumerable.Empty<UserViewModel>();

                        var userId = users.SingleOrDefault(us => us.Email.Equals(login.Email)).Id;

                        var userRoles = _dataContext.UserRoles.Where(ur => ur.UserId == userId);

                        var roles = new List<Role>();
                        foreach (var userRole in userRoles)
                        {
                            var role = _dataContext.Roles.SingleOrDefault(r => r.Id == userRole.RoleId);
                            roles.Add(role);
                        }

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, login.Email),
                            new Claim(ClaimTypes.Email, login.Email),
                            new Claim(ClaimTypes.Role, roles.First().Name),//Role or Roles :(
                        };

                        var claimsIdentity = new ClaimsIdentity(
                            claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);

                        return RedirectToAction("Index", "Home");
                    }
                }

            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "Sorry, something went wrong while logging in. " +
                    "Please try again. Contact administrator if the problem persists.");
                return View(login);
            }
            ModelState.AddModelError(string.Empty, "Invalid Login, please try again.");
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}