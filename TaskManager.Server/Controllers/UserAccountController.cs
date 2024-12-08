using Microsoft.AspNetCore.Mvc;
using TaskManager.Server.EntitiesManagement;
using TaskManager.Server.Models;
using TaskManager.Server.Models.Records;
using TaskManager.Server.Modules.Services;

namespace TaskManager.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountController : ControllerBase
    {
        private readonly TaskManagerContext _taskManagerContext;
        private readonly IConfiguration _configuration;

        public UserAccountController(TaskManagerContext context, IConfiguration config)
        {
            _taskManagerContext = context;
            _configuration = config;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserAccount account)
        {
            try
            {
                if (account == null) return BadRequest("Info cannot be null");
                if(await _taskManagerContext.UserAccounts.AnyAsync(a => a.email == account.email)) return BadRequest("Email already exists");
                account.Id = Guid.NewGuid();
                account.password = BCrypt.Net.BCrypt.HashPassword(account.password);

                _taskManagerContext.UserAccounts.Add(account);
                await _taskManagerContext.SaveChangesAsync();

                return Ok(new { message = $"User created successfully. {account.fullName}" });
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"An error occurred while saving the object: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginLoad load)
        {
            var user = await _taskManagerContext.UserAccounts.FirstOrDefaultAsync(a => a.email.Equals(load.Email));
            AuthService auth = new(_configuration);

            if(user == null || !auth.VerifyPassword(load.Password, user.password)) { return Unauthorized("Invalid Email or Password"); }

            var token = auth.GenerateJwtToken(user);

            return Ok(new
            {
                Token = token,
                UserId = user.Id,
                Email = user.email,
                FirstName = user.fullName,
            });
        }
    }
}
