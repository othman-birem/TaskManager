using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.Server.EntitiesManagement;
using TaskManager.Server.Models;
using TaskManager.Server.Models.Records;

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
                account.Id = Guid.NewGuid().ToString();
                account.password = BCrypt.Net.BCrypt.HashPassword(account.password);

                _taskManagerContext.UserAccounts.Add(account);
                await _taskManagerContext.SaveChangesAsync();

                return Ok(new { message = $"User created successfully. {account.firstName}" });
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

            if(user == null || !VerifyPassword(load.Password, user.password)) { return Unauthorized("Invalid Email or Password"); }

            var token = GenerateJwtToken(user);

            return Ok(new
            {
                Token = token,
                UserId = user.Id,
                Email = user.email,
                FirstName = user.firstName,
                SecondName = user.secondName
            });
        }

        #region Helpers
        private bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        private string GenerateJwtToken(UserAccount user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim("firstName", user.firstName),
                new Claim("secondName", user.secondName)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}
