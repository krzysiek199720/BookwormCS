using Bookworm.Data.EntityConfiguration;
using Bookworm.Entities;
using Bookworm.Entities.Auth;
using Bookworm.Entities.BookData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookworm.Data;

public class DataContext : IdentityDbContext<AppUser>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Series> Series { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration<AppUser>(new AppUserConfiguration());
        builder.ApplyConfiguration<Author>(new AuthorConfiguration());
        builder.ApplyConfiguration<Book>(new BookConfiguration());
        builder.ApplyConfiguration<Category>(new CategoryConfiguration());
        builder.ApplyConfiguration<Publisher>(new PublisherConfiguration());
        builder.ApplyConfiguration<Series>(new SeriesConfiguration());
    }
}