
using dotnet.DTO;
using dotnet.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace dotnet.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRegistrationService _userRegistrationService;

        public UserController(IUserRegistrationService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRegistrationModel user)
        {
            try
            {
                int userId = await _userRegistrationService.CreateUser(user);
                return Ok(userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userRegistrationService.GetUserById(id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userRegistrationService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserRegistrationModel user)
        {
            try
            {
                int result = await _userRegistrationService.UpdateUser(user);
                if (result == 0)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                int result = await _userRegistrationService.DeleteUser(id);
                if (result == 0)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
