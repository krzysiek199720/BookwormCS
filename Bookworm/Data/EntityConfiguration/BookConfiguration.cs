using Bookworm.Entities.BookData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookworm.Data.EntityConfiguration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.ISBN)
            .HasMaxLength(13);

        builder.HasMany(b => b.Authors)
            .WithMany(a => a.Books);

        builder.HasMany(b => b.Categories)
            .WithMany(c => c.Books);

        builder.HasOne(b => b.Series)
            .WithMany(s => s.Books)
            .HasForeignKey(b => b.SeriesId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(b => b.Publisher)
            .WithMany(p => p.Books)
            .HasForeignKey(b => b.PublisherId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}