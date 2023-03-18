using Bookworm.Entities.BookData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookworm.Data.EntityConfiguration;

public class SeriesConfiguration : IEntityTypeConfiguration<Series>
{
    public void Configure(EntityTypeBuilder<Series> builder)
    {
        builder.HasMany(s => s.Books)
            .WithOne(b => b.Series)
            .HasForeignKey(b => b.SeriesId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}