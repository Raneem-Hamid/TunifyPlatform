using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.Services
{
    public class JwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<Account> _signInManager;

        public JwtTokenService(IConfiguration configuration, SignInManager<Account> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }
        public static TokenValidationParameters ValidateToken(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(configuration),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        }

        private static SecurityKey GetSecurityKey(IConfiguration configuration) 
        {
            var SecretKey = configuration["JWT:SecretKey"];
            if (SecretKey == null)
            {
                throw new InvalidOperationException(" jwt secret key is not exsist ");
            }

            var SecretBytes = Encoding.UTF8.GetBytes(SecretKey);
             
            return new SymmetricSecurityKey(SecretBytes);
        }

        public async Task<string> GenerateToken(Account account , TimeSpan expiryDate)
        {
            var userPrincipal = await _signInManager.CreateUserPrincipalAsync(account);
            if (userPrincipal == null)
            {
                return null;
            }
            var SignInKey = GetSecurityKey(_configuration);
            var token = new JwtSecurityToken
                (
                signingCredentials: new SigningCredentials(SignInKey, SecurityAlgorithms.HmacSha256),
                claims: userPrincipal.Claims,
                expires:DateTime.UtcNow + expiryDate
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
