using System.Text;
using Bookworm.Data;
using Bookworm.Entities.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Bookworm.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 2;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        })
            .AddEntityFrameworkStores<DataContext>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(config["TokenKey"] ?? throw new InvalidOperationException())),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        
        services.AddAuthorization(opt => 
        {
            opt.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
        });
        
        return services;
    }
}