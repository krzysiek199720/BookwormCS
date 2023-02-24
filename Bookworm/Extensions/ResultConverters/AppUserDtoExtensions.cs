using Bookworm.DTO.Results;
using Bookworm.Entities.Auth;

namespace Bookworm.Extensions.ResultConverters;

public static class AppUserDtoExtensions
{
    public static LoginDto ToLoginDto(this AppUser appUser, string token)
    {
        return new LoginDto
        {
            Token = token,
            Email = appUser.Email ?? ""
        };
    }
}