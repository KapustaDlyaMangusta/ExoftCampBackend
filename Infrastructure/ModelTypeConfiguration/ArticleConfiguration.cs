using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelTypeConfiguration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(article => article.Id);
            builder.HasIndex(article => article.Id).IsUnique();
            builder.Property(article => article.Title).HasMaxLength(200);
            builder.Property(article => article.Details).HasMaxLength(400);
            builder.HasOne<User>(article => article.User)
                .WithMany(user => user.Articles)
                .HasForeignKey(article => article.UserId);
        }
    }
}
