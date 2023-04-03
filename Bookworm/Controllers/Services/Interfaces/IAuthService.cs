using Bookworm.DTO;
using Bookworm.DTO.Results;
using Bookworm.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace Bookworm.Controllers.Services.Interfaces;

public interface IAuthService
{
    public AppUser Get(string userId);
    public AppUser GetUserByEmail(string email);
    public Task<bool> CheckPassword(AppUser user, string password);
    public Task<string> CreateToken(AppUser user);
    public Task<IdentityResult> CreateUser(AppUser user, string password);
    public Task<IdentityResult> AddRole(AppUser user, string role);
}