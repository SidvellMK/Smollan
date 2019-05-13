using System;
using System.Threading.Tasks;
using DataAccess.Models;
using FinanceReportingRegistrationAPI.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FinanceReportingRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // POST api/<controller>
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody]Role role)
        {
            try
            {
                var roleId = await _roleService.AddRole(role);
                if (roleId < 1)
                {
                    return BadRequest(new
                    {
                        message = "Something went wrong while saving, please try again." +
                                                                 " Call administrator if the problem persists."
                    });
                }

                return Ok();
            }
            catch (NullReferenceException)
            {
                return BadRequest(new { message = "Something went wrong, please try again." });
            }
        }

        // GET: api/<controller>
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var roles = _roleService.GetAll();
            return Ok(roles);
        }

        // GET api/<controller>/5
        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            try
            {
                var role = await _roleService.GetRole(id);

                if (role == null)
                {
                    return NotFound();
                }

                return Ok(role);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Sorry please check again the role and try again." });
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole([FromBody]Role role)
        {
            try
            {
                await _roleService.UpdateRole(role);
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
        public IActionResult DeleteRole(int id)
        {
            try
            {
                _roleService.DeleteRole(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Something went wrong, please try again." });
            }
        }
    }
}