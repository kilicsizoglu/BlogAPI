using Microsoft.EntityFrameworkCore;

namespace BlogAPI;

public class BlogDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=exam01;userid=sa;password=");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<APIKey> apikeys;
    public DbSet<BlogMessage> blogMessages;
    public DbSet<Category> categories;
    public DbSet<User> users;
}
