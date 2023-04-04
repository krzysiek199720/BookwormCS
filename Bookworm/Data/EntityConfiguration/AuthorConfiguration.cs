using Bookworm.Entities.BookData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookworm.Data.EntityConfiguration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(x => x.FirstName).IsRequired(false).HasMaxLength(20);
        builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(40);
        builder.Property(x => x.DateOfBirth).IsRequired(false);
        builder.Property(x => x.DateOfDeath).IsRequired(false);
        builder.Property(x => x.About).HasDefaultValue("").HasMaxLength(250);
        builder.Property(x => x.PhotoUrl);
        
        builder.HasMany(a => a.Books)
            .WithMany(b => b.Authors);
    }
}