using Bookworm.Entities.BookData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookworm.Data.EntityConfiguration;

public class SeriesConfiguration : IEntityTypeConfiguration<Series>
{
    public void Configure(EntityTypeBuilder<Series> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(25);
        builder.Property(x => x.About).HasMaxLength(50).IsRequired(false);
        
        builder.HasMany(s => s.Books)
            .WithOne(b => b.Series)
            .HasForeignKey(b => b.SeriesId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}