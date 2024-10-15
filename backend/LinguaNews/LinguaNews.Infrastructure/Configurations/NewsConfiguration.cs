using LinguaNews.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinguaNews.Infrastructure.Configurations;

public class NewsConfiguration : IEntityTypeConfiguration<News>
{
    public void Configure(EntityTypeBuilder<News> builder)
    {
        builder.HasKey(n => n.Id);
        builder.Property(n => n.Title).IsRequired().HasMaxLength(100);
        builder.Property(n => n.Slug).IsRequired().IsUnicode();
        builder.HasOne<Category>()
            .WithMany()
            .HasForeignKey(n => n.CategoryId)
            .IsRequired();
    }
}