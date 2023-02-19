using Bookworm.Services;
using Bookworm.Services.Interfaces;

namespace Bookworm.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddScoped<ITokenService, TokenService>();

        return services;
    }
}