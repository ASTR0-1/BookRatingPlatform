using BookRatingPlatform.BLL.DTO;
using FluentValidation;

namespace BookRatingPlatform.BLL.Validation;

public class BookForCreationDtoValidator : AbstractValidator<BookForCreationDto>
{
	public BookForCreationDtoValidator()
	{
		RuleFor(e => e.Title)
			.NotEmpty();
		
		RuleFor(e => e.Author)
			.NotEmpty();

		RuleFor(e => e.Cover)
			.NotEmpty();

		RuleFor(e => e.Content)
			.NotEmpty();

		RuleFor(e => e.Genre)
			.NotEmpty();
	}
}
