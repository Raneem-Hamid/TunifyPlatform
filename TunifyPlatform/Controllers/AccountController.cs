using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TunifyPlatform.Models.DTO;
using TunifyPlatform.Repositories.Interfaces;
using TunifyPlatform.Repositories.Services;

namespace TunifyPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;

        public AccountController(IAccount account)
        {
            _account = account;
        }

        [HttpPost("Register")]

        public async Task<ActionResult<AccountDto>> Register (RegisterDto registerDto)
        {
            var user = await _account.Register(registerDto , this.ModelState);
            if (ModelState.IsValid)
            {
                return user;
            }
            if (user == null)
            {
                return Unauthorized();
            }
            return BadRequest();
        }

        [HttpPost("Login")]

        public async Task<ActionResult<AccountDto>> Login (LoginDto loginDto)
        {
            var user = await _account.Login(loginDto.Username , loginDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            return user;
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _account.Logout();
            return Ok("Logged out successfully");
        }

    }
}
