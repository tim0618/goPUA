using backend.Model;
using Microsoft.EntityFrameworkCore;

namespace backend.AppDBContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<UserModel> User { get; set; }
    public DbSet<ActivityModel> Activity { get; set; }

}
