using AutoMapper;
using BookRatingPlatform.BLL.DTO;
using BookRatingPlatform.BLL.Interfaces;
using BookRatingPlatform.DAL.Interfaces;
using BookRatingPlatform.DAL.Models;
using FluentValidation;

namespace BookRatingPlatform.BLL.Services;

public class RatingService : IRatingService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<RatingForAddingDto> _validator;

    public RatingService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<RatingForAddingDto> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<int> AddRatingAsync(int bookId, RatingForAddingDto rating)
    {
        var book = await _unitOfWork.BookRepository.GetAsync(bookId);

        if (book == null)
            throw new KeyNotFoundException($"Cannot find book with given id: {bookId}");

        await _validator.ValidateAndThrowAsync(rating);

        var mappedRating = _mapper.Map<Rating>(rating);
        mappedRating.BookId = bookId;

        var createdRating = await _unitOfWork.RatingRepository.AddAsync(mappedRating);

        return createdRating != null ? createdRating.Id : 0;
    }
}
