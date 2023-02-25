using System.Linq.Dynamic.Core;
using System.Reflection;
using AutoMapper;
using BookRatingPlatform.BLL.DTO;
using BookRatingPlatform.BLL.Interfaces;
using BookRatingPlatform.DAL.Interfaces;
using BookRatingPlatform.DAL.Models;
using FluentValidation;
using Microsoft.Extensions.Configuration;

namespace BookRatingPlatform.BLL.Services;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<BookForCreationDto> _validator;
    private readonly IConfiguration _configuration;

    public BookService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<BookForCreationDto> validator, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
        _configuration = configuration;
    }

    public async Task<int> AddBookAsync(BookForCreationDto book)
    {
        await _validator.ValidateAndThrowAsync(book);

        var mappedBook = _mapper.Map<Book>(book);

        var createdBook = await _unitOfWork.BookRepository.AddAsync(mappedBook);

        return createdBook != null ? createdBook.Id : 0;
    }

    public async Task<int> UpdateBookAsync(BookForCreationDto book)
    {
        await _validator.ValidateAndThrowAsync(book);

        var searchedBook = await _unitOfWork.BookRepository.GetAsync((int)book.Id);

        if (searchedBook == null)
            return 0;

        var mappedBook = _mapper.Map<Book>(book);

        await _unitOfWork.BookRepository.UpdateAsync(mappedBook);

        return mappedBook.Id;
    }

    public async Task<bool> DeleteBookAsync(int id, string secret)
    {
        var book = await _unitOfWork.BookRepository.GetAsync(id);

        if (book == null)
            throw new KeyNotFoundException($"Cannot find book with given id: {id}");

        if (secret != _configuration["SecretSettings:SecretKey"])
            return false;

        await _unitOfWork.BookRepository.DeleteAsync(book);

        return true;
    }

    public async Task<IEnumerable<BookDto>> GetAllBooksAsync(string? sortColumn, string? sortOrder = "asc")
    {
        var books = _unitOfWork.BookRepository.Find(b => true).AsQueryable();

        if (!string.IsNullOrEmpty(sortColumn)
            && IsValidProperty(sortColumn))
        {
            sortOrder = !string.IsNullOrEmpty(sortOrder) && sortOrder.ToUpper() == "DESC" ? "DESC" : "ASC";

            books = books.OrderBy(
                string.Format("{0} {1}",
                sortColumn,
                sortOrder)
                );
        }

        var booksToMap = await Task.FromResult(books.ToList());
        var mappedBooks = _mapper.Map<List<BookDto>>(booksToMap);

        return mappedBooks;
    }

    public async Task<BookDetailsDto> GetBookDetailsAsync(int id)
    {
        var book = await _unitOfWork.BookRepository.GetAsync(id);

        if (book == null)
            throw new KeyNotFoundException($"Cannot find book with given id: {id}");

        var mappedBook = _mapper.Map<BookDetailsDto>(book);

        return mappedBook;
    }

    public async Task<IEnumerable<BookDto>> GetTopBooksAsync(string? filter)
    {
        IEnumerable<Book> books;

        if (!string.IsNullOrEmpty(filter))
            books = _unitOfWork.BookRepository.Find(b => b.Genre == filter && b.Reviews.Count() >= 10);
        else
            books = _unitOfWork.BookRepository.Find(b => b.Reviews.Count() >= 10);

        var mappedBooks = _mapper.Map<List<BookDto>>(await Task.FromResult(books.ToList()));

        return mappedBooks;
    }

    private static bool IsValidProperty(string propertyName, bool throwExceptionIfNotFound = true)
    {
        var prop = typeof(Book).GetProperty(propertyName,
            BindingFlags.IgnoreCase |
            BindingFlags.Public |
            BindingFlags.Static |
            BindingFlags.Instance);

        if (prop == null && throwExceptionIfNotFound)
            throw new NotSupportedException(string.Format(
                "ERROR: Property '{0}' does not exist.",
                propertyName));

        return prop != null;
    }
}
