using BookRatingPlatform.DAL.Interfaces;
using BookRatingPlatform.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRatingPlatform.DAL.Repositories;

public class ReviewRepository : IGenericRepository<Review>
{
    private static ApplicationDbContext _context;

    public ReviewRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Review entity)
    {
        _context.Reviews.Add(entity);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Review entity)
    {
        _context.Reviews.Remove(entity);

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Review>> GetAllAsync()
    {
        return await _context.Reviews
            .Include(r => r.Book)
            .ToListAsync();
    }

    public async Task<Review> GetAsync(int id)
    {
        return await _context.Reviews
            .Include(r => r.Book)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task UpdateAsync(Review entity)
    {
        _context.Reviews.Update(entity);

        await _context.SaveChangesAsync();
    }
}
