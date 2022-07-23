using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelTypeConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(article => article.UserId);
            builder.HasIndex(article => article.UserId).IsUnique();
            builder.Property(article => article.AboutMe).HasMaxLength(400);
        }
    }
}
