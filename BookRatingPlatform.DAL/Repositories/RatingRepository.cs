﻿using BookRatingPlatform.DAL.Interfaces;
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

    public async Task AddAsync(Rating entity)
    {
        _context.Rating.Add(entity);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Rating entity)
    {
        _context.Rating.Remove(entity);

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Rating>> GetAllAsync()
    {
        return await _context.Rating
            .Include(r => r.Book)
            .ToListAsync();
    }

    public async Task<Rating> GetAsync(int id)
    {
        return await _context.Rating
            .Include(r => r.Book)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task UpdateAsync(Rating entity)
    {
        _context.Rating.Update(entity);

        await _context.SaveChangesAsync();
    }
}