using Microsoft.EntityFrameworkCore;

namespace altr_server.data;

public sealed class DbCtx : DbContext
{
    public DbSet<Community> Community { get; set; }
    public DbSet<Post> Post { get; set; }
    public DbSet<User> User { get; set; }

    public DbCtx() { }

    public DbCtx(DbContextOptions<DbCtx> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseIdentityColumns();

        modelBuilder.Entity<User>().HasAlternateKey(u => u.Username);

        modelBuilder.Entity<Community>().HasAlternateKey(c => c.CommunityName);
    }
        
}
