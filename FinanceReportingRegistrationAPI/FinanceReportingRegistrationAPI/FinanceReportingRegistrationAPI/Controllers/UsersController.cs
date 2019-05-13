using System;
using System.Threading.Tasks;
using DataAccess.Models;
using FinanceReportingRegistrationAPI.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceReportingRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]Login loginCredentials)
        {
            try
            {
                var user = await _userService.Authenticate(loginCredentials);

                if (user == null)
                {
                    return BadRequest(new { message = "Email or password is incorrect" });
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Email or password is incorrect" });
            }
        }

        // GET: api/<controller>
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        // GET api/<controller>/5
        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUser(id);

                if (user == null)
                {
                    return NotFound();
                }

                //Remove comments after the authenticate method is good
                //Only allow the admins to access other records
                //var currentUserId = int.Parse(User.Identity.Name);

                //if (id != currentUserId && User.IsInRole("Admin"))
                //{
                //    return Forbid();
                //}

                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest(new { message="Sorry please check again the user and try again."});
            }
        }

        // POST api/<controller>
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]User user)
        {
            try
            {
                var userId = await _userService.AddUser(user);
                if (userId < 1)
                {
                    return BadRequest(new { message = "Something went wrong while saving, please try again." +
                                                                 " Call administrator if the problem persists."});
                }

                return Ok();
            }
            catch (NullReferenceException)
            {
                return BadRequest(new { message = "Something went wrong, please try again."});
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody]User user)
        {
            try
            {
                await _userService.UpdateUser(user);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Something went wrong, please try again." });
            }
        }

        // DELETE api/<controller>/5
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Something went wrong, please try again." });
            }
        }
    }
}
