using altr.Data.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace altr.Data;

public sealed class AltrDb : DbContext
{
    public AltrDb() { }

    public AltrDb(DbContextOptions<AltrDb> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder
        .UseIdentityColumns()
        .HasPostgresEnum<UserRoles>()
        .HasPostgresEnum<CommunityMode>();
}
