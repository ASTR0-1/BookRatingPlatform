using System.Linq;
using BookRatingPlatform.DAL.Interfaces;
using BookRatingPlatform.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRatingPlatform.DAL.Repositories;

public class RatingRepository : IGenericRepository<Rating>
{
    private static ApplicationDbContext _context;

    public RatingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Rating> AddAsync(Rating entity)
    {
        _context.Ratings.Add(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(Rating entity)
    {
        _context.Ratings.Remove(entity);

        await _context.SaveChangesAsync();
    }

    public async Task<IQueryable<Rating>> FindAsync(Func<Rating, bool> predicate)
    {
        return await Task.FromResult(_context.Ratings
            .AsNoTracking()
            .Include(r => r.Book)
            .Where(predicate)
            .AsQueryable());
    }

    public async Task<IEnumerable<Rating>> GetAllAsync()
    {
        return await _context.Ratings
            .AsNoTracking()
            .Include(r => r.Book)
            .ToListAsync();
    }

    public async Task<Rating> GetAsync(int id)
    {
        return await _context.Ratings
            .AsNoTracking()
            .Include(r => r.Book)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task UpdateAsync(Rating entity)
    {
        _context.Ratings.Update(entity);

        await _context.SaveChangesAsync();
    }
}
