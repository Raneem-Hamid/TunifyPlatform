using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using TunifyPlatform.Models.DTO;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IAccount
    {
        public Task<AccountDto> Register(RegisterDto registerDto , ModelStateDictionary modelState);

        public Task<AccountDto> Login(string username , string password);

        Task Logout();

        public Task<AccountDto> UserProfile(ClaimsPrincipal claimsPrincipal);


    }
}
