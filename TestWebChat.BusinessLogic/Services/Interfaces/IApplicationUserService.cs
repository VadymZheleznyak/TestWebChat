namespace TestWebChat.BusinessLogic.Services.Interfaces
{
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using TestWebChat.BusinessLogic.Models;
    using TestWebChat.Infrastructure.Identity;

    public interface IApplicationUserService
    {
        Task<IdentityResult> CreateUser(User user);
        Task<string> LoginUser(LoginUser model);
        Task<ApplicationUser> GetById(string userId);
    }
}
