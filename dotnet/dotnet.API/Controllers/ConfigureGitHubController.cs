
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DTO;
using dotnet.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigureGitHubController : ControllerBase
    {
        private readonly IConfigureGitHubService _configureGitHubService;

        public ConfigureGitHubController(IConfigureGitHubService configureGitHubService)
        {
            _configureGitHubService = configureGitHubService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ConfigureGitHubModel model)
        {
            var result = await _configureGitHubService.CreateAsync(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _configureGitHubService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _configureGitHubService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ConfigureGitHubModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var result = await _configureGitHubService.UpdateAsync(model);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _configureGitHubService.DeleteAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
