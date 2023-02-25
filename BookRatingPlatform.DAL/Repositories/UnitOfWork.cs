using BookRatingPlatform.DAL.Interfaces;
using BookRatingPlatform.DAL.Models;

namespace BookRatingPlatform.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    private BookRepository _bookRepository;
    private RatingRepository _ratingRepository;
    private ReviewRepository _reviewRepository;

    private static readonly object _lock = new();

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public BookRepository BookRepository
    {
        get
        {
            lock (_lock)
            {
                _bookRepository ??= new BookRepository(_context);

                return _bookRepository;
            }
        }
    }

    public RatingRepository RatingRepository
    {
        get
        {
            lock (_lock)
            {
                _ratingRepository ??= new RatingRepository(_context);

                return _ratingRepository;
            }
        }
    }

    public ReviewRepository ReviewRepository
    {
        get
        {
            lock (_lock)
            {
                _reviewRepository ??= new ReviewRepository(_context);

                return _reviewRepository;
            }
        }
    }
}
