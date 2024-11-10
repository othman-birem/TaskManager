using Microsoft.AspNetCore.Mvc;
using TaskManager.Server.Models;

namespace TaskManager.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountController : ControllerBase
    {
        private readonly ILogger<UserAccountController> _logger;

        public UserAccountController(ILogger<UserAccountController> logger) { _logger = logger; }

        [HttpGet(Name = "GetUserAccount")]
        public IEnumerable<UserAccount> Get()
        {
            return Enumerable.Range(1, 2).Select(index => new UserAccount
            {
                Id = "01",
                firstName = "othman",
                secondName = (index + 2).ToString(),
                dateOfBirth = DateTime.Now,
                occupation = "Engineer",
                email = "biremothman@gmail.com",
                password = "password"
            })
            .ToArray();
        }
        [HttpPost]
        public IActionResult Post(UserAccount account)
        {
            return Ok(new { message = $"User created successfully. {account.firstName}" });
        }
    }
}
