using BookRatingPlatform.DAL.Interfaces;
using BookRatingPlatform.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRatingPlatform.DAL.Repositories;

public class BookRepository : IGenericRepository<Book>
{
    private static ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Book> AddAsync(Book entity)
    {
        _context.Books.Add(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(Book entity)
    {
        _context.Books.Remove(entity);

        await _context.SaveChangesAsync();
    }

    public IEnumerable<Book> Find(Func<Book, bool> predicate)
    {
        return _context.Books
            .AsNoTracking()
            .Include(b => b.Ratings)
            .Include(b => b.Reviews)
            .Where(predicate)
            .ToList();
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Books
            .AsNoTracking()
            .Include(b => b.Ratings)
            .Include(b => b.Reviews)
            .ToListAsync();
    }

    public async Task<Book> GetAsync(int id)
    {
        return await _context.Books
            .AsNoTracking()
            .Include(b => b.Ratings)
            .Include(b => b.Reviews)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task UpdateAsync(Book entity)
    {
        _context.Books.Update(entity);

        await _context.SaveChangesAsync();
    }
}
