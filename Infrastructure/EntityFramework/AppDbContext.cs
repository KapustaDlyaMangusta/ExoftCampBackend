using Application.Interfaces;
using Domain.Models;
using Infrastructure.ModelTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ArticleConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
