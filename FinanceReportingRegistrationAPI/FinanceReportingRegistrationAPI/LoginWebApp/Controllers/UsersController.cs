using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using DataAccess.Models;
using LoginWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace LoginWebApp.Controllers
{
    public class UsersController : Controller
    {
        private IConfiguration _configuration;
        private DataContext _dataContext;

        public UsersController(IConfiguration configuration, DataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            IEnumerable<UserViewModel> users = Enumerable.Empty<UserViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetSection("ApiUrls").GetSection("LoginApi").Value);

                var requestTask = client.GetAsync("Users");
                requestTask.Wait();

                var result = requestTask.Result;

                if (!result.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return View(users);
                }

                var readTask = result.Content.ReadAsAsync<IList<UserViewModel>>();
                readTask.Wait();

                users = readTask.Result;

            }

            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new UserEditorViewModel
            {
                RoleSelectList = _dataContext.Roles.Where(x => x.IsDeleted == false).ToList().Select(x =>
                    new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
                    })
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create([Bind("FirstName, LastName, Email, Password, PhoneNumber, Roles")] UserEditorViewModel userVm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Sorry, please try again or contact your administrator.");

                userVm.RoleSelectList = _dataContext.Roles.Where(x => x.IsDeleted == false).ToList().Select(x =>
                new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
                return View(userVm);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetSection("ApiUrls").GetSection("LoginApi").Value);

                var user = new User
                {
                    FirstName = userVm.FirstName,
                    LastName = userVm.LastName,
                    Password = userVm.Password,
                    PhoneNumber = userVm.PhoneNumber,
                    Email = userVm.Email
                };

                foreach (var roleId in userVm.Roles)
                {
                    user.Roles.Add(new UserRole
                    {
                        RoleId = roleId,
                        UserId = userVm.Id
                    });
                }

                var postTask = client.PostAsJsonAsync<User>("Users", user);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Sorry, please try again or contact your administrator.");

            userVm.RoleSelectList = _dataContext.Roles.Where(x => x.IsDeleted == false).ToList().Select(x =>
            new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            return View(userVm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = new User();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetSection("ApiUrls").GetSection("LoginApi").Value);
                var requestTask = client.GetAsync($"Users/{id.ToString()}");
                requestTask.Wait();

                var result = requestTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<User>();
                    readTask.Wait();

                    user = readTask.Result;
                }
            }

            var userViewModel = new UserEditorViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };

            foreach (var role in user.Roles)
            {
                userViewModel.Roles.Add(role.RoleId);
            }

            userViewModel.RoleSelectList = _dataContext.Roles
                .Where(x => x.IsDeleted == false)
                .ToList().Select(x =>
                new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });

            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Edit(UserEditorViewModel userVm)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_configuration.GetSection("ApiUrls").GetSection("LoginApi").Value);

                    var user = new User
                    {
                        Id = userVm.Id,
                        FirstName = userVm.FirstName,
                        LastName = userVm.LastName,
                        PhoneNumber = userVm.PhoneNumber,
                        Email = userVm.Email
                    };

                    if (!string.IsNullOrWhiteSpace(userVm.Password))
                    {
                        user.Password = userVm.Password;
                    }

                    foreach (var roleId in userVm.Roles)
                    {
                        user.Roles.Add(new UserRole
                        {
                            RoleId = roleId,
                            UserId = userVm.Id,
                        });
                    }

                    var postTask = client.PutAsJsonAsync<User>("Users/UpdateUser", user);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong while saving your information. " +
                    "Please try again or contact administrator if the problem persists.");
            }

            userVm.RoleSelectList = _dataContext.Roles
                .Where(x => x.IsDeleted == false)
                .ToList().Select(x =>
                new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });

            return View(userVm);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = new User();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetSection("ApiUrls").GetSection("LoginApi").Value);
                var requestTask = client.GetAsync($"Users/{id.ToString()}");
                requestTask.Wait();

                var result = requestTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<User>();
                    readTask.Wait();

                    user = readTask.Result;
                }
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetSection("ApiUrls").GetSection("LoginApi").Value);

                var deleteTask = client.DeleteAsync($"Users/{id.ToString()}");
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var user = new User();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetSection("ApiUrls").GetSection("LoginApi").Value);
                var requestTask = client.GetAsync($"Users/{id.ToString()}");
                requestTask.Wait();

                var result = requestTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<User>();
                    readTask.Wait();

                    user = readTask.Result;
                }
            }

            var userViewModel = new UserDetailsViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };

            foreach (var roleItem in user.Roles)
            {
                var role = _dataContext.Roles.Find(roleItem.RoleId);

                if (role != null)
                {
                    userViewModel.Roles.Add(role);
                }
            }
            return View(userViewModel);
        }
    }
}