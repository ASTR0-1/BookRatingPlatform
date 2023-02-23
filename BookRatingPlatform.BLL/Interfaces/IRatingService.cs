using BookRatingPlatform.BLL.DTO;

namespace BookRatingPlatform.BLL.Interfaces;

public interface IRatingService
{
    Task<int> AddRatingAsync(int bookId, RatingForAddingDto rating);
}
