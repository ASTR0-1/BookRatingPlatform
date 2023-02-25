using BookRatingPlatform.DAL.Repositories;

namespace BookRatingPlatform.DAL.Interfaces;

public interface IUnitOfWork
{
    public BookRepository BookRepository { get; }

    public RatingRepository RatingRepository { get; }

    public ReviewRepository ReviewRepository { get; }
}
