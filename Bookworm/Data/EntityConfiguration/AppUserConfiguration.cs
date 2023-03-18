using Bookworm.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookworm.Data.EntityConfiguration;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasMany(u => u.LikedBooks)
            .WithMany(b => b.Fans);
        
        builder.HasMany(u => u.LikedSeries)
            .WithMany(s => s.Fans);
    }
}