using Microsoft.AspNetCore.Mvc.ModelBinding;
using TunifyPlatform.Models.DTO;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IAccount
    {
        public Task<AccountDto> Register(RegisterDto registerDto , ModelStateDictionary modelState);

        public Task<AccountDto> Login(string username , string password);

        Task Logout();


    }
}
