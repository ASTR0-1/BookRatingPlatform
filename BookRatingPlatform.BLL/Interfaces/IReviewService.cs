using BookRatingPlatform.BLL.DTO;

namespace BookRatingPlatform.BLL.Interfaces;

public interface IReviewService
{
    Task<int> AddReviewAsync(int bookId, ReviewForAddingDto review);
}
