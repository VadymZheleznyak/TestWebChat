namespace TestWebChat.BusinessLogic.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using TestWebChat.BusinessLogic.Models;
    using TestWebChat.BusinessLogic.Services.Interfaces;
    using TestWebChat.Infrastructure.Identity;

    public class ApplicationUserService : IApplicationUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationSettings _appSettings;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, IOptions<ApplicationSettings> options)
        {
            _userManager = userManager;
            _appSettings = options.Value;
        }

        public async Task<IdentityResult> CreateUser(User user)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email
            };
            return await _userManager.CreateAsync(applicationUser, user.Password);
        }

        public async Task<string> LoginUser(LoginUser model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return token;
            }
            return string.Empty;
        }

        public async Task<ApplicationUser> GetById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }
    }
}
