using BookRatingPlatform.BLL;
using BookRatingPlatform.BLL.DTO;
using BookRatingPlatform.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookRatingPlatform.API.Controllers;

[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IReviewService _reviewService;
    private readonly IRatingService _ratingService;

    public BooksController(IBookService bookService, IReviewService reviewService, IRatingService ratingService)
    {
        _bookService = bookService;
        _reviewService = reviewService;
        _ratingService = ratingService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks([FromQuery] string? sortColumn,
        [FromQuery] string? sortOrder = "ASC")
    {
        IEnumerable<BookDto> books = await _bookService.GetAllBooksAsync(sortColumn, sortOrder);

        return Ok(books);
    }

    [HttpGet("api/recommended")]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetTopTenBooks([FromQuery] string? genre)
    {
        IEnumerable<BookDto> books = await _bookService.GetTopBooksAsync(genre);

        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDetailsDto>> GetBookDetails(int id)
    {
        BookDetailsDto bookDetails = await _bookService.GetBookDetailsAsync(id);

        return Ok(bookDetails);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id, [FromQuery] string secret)
    {
        bool isSucceed = await _bookService.DeleteBookAsync(id, secret);

        if (!isSucceed)
            return Unauthorized($"Provided secret incorrect: {secret}");

        return Ok();
    }

    [HttpPost("save")]
    public async Task<ActionResult<int>> PostBook([FromBody] BookForCreationDto book)
    {
        int bookId = (int)book.Id;

        if (bookId != 0)
            await _bookService.UpdateBookAsync(book);
        else
            bookId = await _bookService.AddBookAsync(book);

        return Ok(bookId);
    }

    [HttpPut("{id}/review")]
    public async Task<ActionResult<int>> PutReview(int id, [FromBody] ReviewForAddingDto review)
    {
        int reviewId = await _reviewService.AddReviewAsync(id, review);

        return Ok(reviewId);
    }

    [HttpPut("{id}/rate")]
    public async Task<ActionResult<int>> PutRating(int id, [FromBody] RatingForAddingDto rating)
    {
        int ratingId = await _ratingService.AddRatingAsync(id, rating);

        return Ok(ratingId);
    }
}
