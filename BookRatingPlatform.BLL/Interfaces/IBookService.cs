using BookRatingPlatform.BLL.DTO;

namespace BookRatingPlatform.BLL.Interfaces;

public interface IBookService
{
    Task<int> AddBookAsync(BookForCreationDto book);

    Task<int> UpdateBookAsync(BookForCreationDto book);

    Task<IEnumerable<BookDto>> GetAllBooksAsync(string? sortColumn, string? sortOrder);

    Task<BookDetailsDto> GetBookDetailsAsync(int id);

    Task<bool> DeleteBookAsync(int id, string secret);

    Task<IEnumerable<BookDto>> GetTopBooksAsync(string? filter);
}
