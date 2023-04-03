using Bookworm.Controllers.Repositories;
using Bookworm.Controllers.Repositories.Interfaces;
using Bookworm.Controllers.Services;
using Bookworm.Controllers.Services.Interfaces;
using Bookworm.DTO;
using Bookworm.Services;
using Bookworm.Services.Interfaces;

namespace Bookworm.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddScoped<ITokenService, TokenService>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IBookService, BookService>()
            .AddScoped<ISearchService, SearchService>()
            ;
        
        services
            .AddScoped<IBookRepository, BookRepository>()
            .AddScoped<IAuthorRepository, AuthorRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<IPublisherRepository, PublisherRepository>()
            .AddScoped<ISeriesRepository, SeriesRepository>()
            ;

        return services;
    }
}