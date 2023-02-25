using BookRatingPlatform.BLL.DTO;
using FluentValidation;

namespace BookRatingPlatform.BLL.Validation;

public class ReviewForAddingDtoValidator : AbstractValidator<ReviewForAddingDto>
{
    public ReviewForAddingDtoValidator()
    {
        RuleFor(e => e.Message)
            .NotEmpty();

        RuleFor(e => e.Reviewer)
            .NotEmpty();
    }
}
