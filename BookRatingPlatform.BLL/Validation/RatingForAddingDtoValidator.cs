using BookRatingPlatform.BLL.DTO;
using FluentValidation;

namespace BookRatingPlatform.BLL.Validation;

public class RatingForAddingDtoValidator : AbstractValidator<RatingForAddingDto>
{
    public RatingForAddingDtoValidator()
    {
        RuleFor(e => e.BookRating)
            .NotEmpty()
            .InclusiveBetween(1.0m, 5.0m);
    }
}
