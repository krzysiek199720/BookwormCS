using Bookworm.Entities.Auth;

namespace Bookworm.Services.Interfaces;

public interface ITokenService
{
    public Task<string> CreateToken(AppUser user);
}