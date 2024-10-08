﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using TunifyPlatform.Models;
using TunifyPlatform.Models.DTO;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class IdentityAccountService : IAccount
    {
        private UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;
        private JwtTokenService _jwtTokenService;
        public IdentityAccountService(UserManager<Account> manager, SignInManager<Account> signInManager, JwtTokenService jwtTokenService)
        {
            _userManager = manager;
            _signInManager = signInManager;
           this. _jwtTokenService = jwtTokenService;
        }

        public async Task<AccountDto> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool passValidation = await _userManager.CheckPasswordAsync(user, password);

            if (passValidation) 
            {
                return new AccountDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await _jwtTokenService.GenerateToken(user , System.TimeSpan.FromDays(7))
                };
            }

            return null;
        }

        public async Task<AccountDto> Register(RegisterDto registerDto, ModelStateDictionary modelState)
        {
            var user = new Account()
            { 
                UserName = registerDto.Username,
                Email = registerDto.Email,
            };

           var result = await _userManager.CreateAsync(user , registerDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user , registerDto.Roles);
                return new AccountDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await _jwtTokenService.GenerateToken(user, System.TimeSpan.FromDays(7)),
                    Roles = await _userManager.GetRolesAsync(user),

                };
            }

            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("Password") ? nameof(registerDto) :
                    error.Code.Contains("Email") ? nameof(registerDto) :
                    error.Code.Contains("Username") ? nameof(registerDto) : "";

                modelState.AddModelError(errorCode, error.Description);
            }
            
            return null;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<AccountDto> UserProfile(ClaimsPrincipal claimsPrincipal)
        {
           var user = await _userManager.GetUserAsync(claimsPrincipal);
            return new AccountDto()
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await _jwtTokenService.GenerateToken(user, System.TimeSpan.FromDays(7))

            };
        }
    }
}
