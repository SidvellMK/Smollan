using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DataAccess.Models;
using LoginWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LoginWebApp.Controllers
{
    public class RolesController : Controller
    {
        private IConfiguration _configuration;

        public RolesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            IEnumerable<RoleViewModel> roles = Enumerable.Empty<RoleViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetSection("ApiUrls").GetSection("LoginApi").Value);

                var requestTask = client.GetAsync("Roles");
                requestTask.Wait();

                var result = requestTask.Result;
                if (!result.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return View(roles);
                }

                var readTask = result.Content.ReadAsAsync<IList<RoleViewModel>>();
                readTask.Wait();

                roles = readTask.Result;
            }
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new RoleEditorViewModel());
        }
        
        [HttpPost]
        public IActionResult Create([Bind("Name")] RoleEditorViewModel roleVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Sorry, please try again or contact your administrator.");

                return View(roleVM);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetSection("ApiUrls").GetSection("LoginApi").Value);

                var role = new Role
                {
                    Name = roleVM.Name
                };

                var postTask = client.PostAsJsonAsync<Role>("Roles", role);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Sorry, please try again or contact your administrator.");
            return View(roleVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var role = new Role();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetSection("ApiUrls").GetSection("LoginApi").Value);
                var requestTask = client.GetAsync($"Roles/{id.ToString()}");
                requestTask.Wait();

                var result = requestTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Role>();
                    readTask.Wait();

                    role = readTask.Result;
                }
            }

            var roleViewModel = new RoleEditorViewModel
            {
                Id = role.Id,
                Name = role.Name,
            };

            return View(roleViewModel);
        }

        [HttpPost]
        public IActionResult Edit(RoleEditorViewModel roleVM)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_configuration.GetSection("ApiUrls").GetSection("LoginApi").Value);

                    var role = new Role
                    {
                        Id = roleVM.Id,
                        Name = roleVM.Name,
                    };

                    var postTask = client.PutAsJsonAsync<Role>("Roles/UpdateRole", role);
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

            return View(roleVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var role = new Role();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetSection("ApiUrls").GetSection("LoginApi").Value);
                var requestTask = client.GetAsync($"Roles/{id.ToString()}");
                requestTask.Wait();

                var result = requestTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Role>();
                    readTask.Wait();

                    role = readTask.Result;
                }
            }

            var roleViewModel = new RoleEditorViewModel
            {
                Id = role.Id,
                Name = role.Name,
            };

            return View(roleViewModel);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetSection("ApiUrls").GetSection("LoginApi").Value);

                var deleteTask = client.DeleteAsync($"Roles/{id.ToString()}");
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
            var role = new Role();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration.GetSection("ApiUrls").GetSection("LoginApi").Value);
                var requestTask = client.GetAsync($"Roles/{id.ToString()}");
                requestTask.Wait();

                var result = requestTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Role>();
                    readTask.Wait();

                    role = readTask.Result;
                }
            }

            var roleViewModel = new RoleEditorViewModel
            {
                Id = role.Id,
                Name = role.Name,
            };

            return View(roleViewModel);
        }

    }
}