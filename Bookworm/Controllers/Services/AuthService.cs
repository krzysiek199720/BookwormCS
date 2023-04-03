using Bookworm.Controllers.Services.Interfaces;
using Bookworm.DTO;
using Bookworm.DTO.Results;
using Bookworm.Entities.Auth;
using Bookworm.Extensions.ResultConverters;
using Bookworm.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Bookworm.Controllers.Services;

public class AuthService : IAuthService
{
    private UserManager<AppUser> UserManager { get; }
    private ITokenService TokenService { get; }

    public AuthService(UserManager<AppUser> userManager, ITokenService tokenService)
    {
        UserManager = userManager;
        TokenService = tokenService;
    }

    public AppUser Get(string userId)
    {
        return UserManager.Users.FirstOrDefault(u => u.Id == userId);
    }
    
    public AppUser GetUserByEmail(string email)
    {
        return UserManager.Users.FirstOrDefault(u => u.Email != null && u.Email.Equals(email));
    }

    public async Task<bool> CheckPassword(AppUser user, string password)
    {
        return await UserManager.CheckPasswordAsync(user, password);
    }
    
    public async Task<string> CreateToken(AppUser user)
    {
        return await TokenService.CreateToken(user);
    }

    public async Task<IdentityResult> CreateUser(AppUser user, string password)
    {
        var result = await UserManager.CreateAsync(user, password);
        return result;
    }

    public async Task<IdentityResult> AddRole(AppUser user, string role)
    {
        return await UserManager.AddToRoleAsync(user, role);
    }
}