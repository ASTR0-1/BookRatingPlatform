using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace BookRatingPlatform.DAL.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {

    }

    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Book> Books { get; set; }

    public DbSet<Rating> Ratings { get; set; }

    public DbSet<Review> Reviews { get; set; }
}
