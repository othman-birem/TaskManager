using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.Server.Models;

namespace TaskManager.Server.Modules.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;

        internal AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Authorize]
        internal bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
        [Authorize]
        internal string GenerateJwtToken(UserAccount user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
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
    }
}
