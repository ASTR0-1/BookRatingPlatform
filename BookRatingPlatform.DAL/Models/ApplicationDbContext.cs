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
	}

	public DbSet<Book> Books { get; set; }

	public DbSet<Rating> Rating { get; set; }

	public DbSet<Review> Reviews { get; set; }
}
