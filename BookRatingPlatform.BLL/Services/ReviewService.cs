using AutoMapper;
using BookRatingPlatform.BLL.DTO;
using BookRatingPlatform.BLL.Interfaces;
using BookRatingPlatform.DAL.Interfaces;
using BookRatingPlatform.DAL.Models;
using FluentValidation;

namespace BookRatingPlatform.BLL.Services;

public class ReviewService : IReviewService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<ReviewForAddingDto> _validator;

    public ReviewService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<ReviewForAddingDto> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<int> AddReviewAsync(int bookId, ReviewForAddingDto review)
    {
        var book = await _unitOfWork.BookRepository.GetAsync(bookId);

        if (book == null)
            throw new KeyNotFoundException($"Cannot find book with given id: {bookId}");

        await _validator.ValidateAndThrowAsync(review);

        var mappedReview = _mapper.Map<Review>(review);
        mappedReview.BookId = bookId;

        var createdReview = await _unitOfWork.ReviewRepository.AddAsync(mappedReview);

        return createdReview != null ? createdReview.Id : 0;
    }
}
