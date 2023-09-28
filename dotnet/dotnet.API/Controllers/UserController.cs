
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DTO;
using dotnet.Service;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRegistrationModel>> GetUser(int id)
        {
            var user = await _userRegistrationService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserRegistrationModel>>> GetUsers()
        {
            var users = await _userRegistrationService.GetUsers();
            return users;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateUser(UserRegistrationModel user)
        {
            var userId = await _userRegistrationService.CreateUser(user);
            return userId;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateUser(int id, UserRegistrationModel user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var updatedUser = await _userRegistrationService.UpdateUser(user);
            return updatedUser;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteUser(int id)
        {
            var deletedUser = await _userRegistrationService.DeleteUser(id);
            return deletedUser;
        }
    }
}
