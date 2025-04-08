using collection.Model;
using Microsoft.EntityFrameworkCore;

namespace collection;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    
    public DbSet<Tool> Tools { get; set; }
    public DbSet<Brand> Brands { get; set; }
}