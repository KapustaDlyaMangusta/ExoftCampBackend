namespace Infrastructure.EntityFramework
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        { 
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
