using Bookworm.Entities.BookData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookworm.Data.EntityConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(25);
        builder.Property(x => x.About).HasMaxLength(50).IsRequired(false);
        
        builder.HasMany(c => c.Books)
            .WithMany(b => b.Categories);
    }
}