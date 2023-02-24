using AutoMapper;
using BookRatingPlatform.BLL.DTO;
using BookRatingPlatform.DAL.Models;

namespace BookRatingPlatform.BLL.Mappers;

public class BookMappingProfile : Profile
{
	public BookMappingProfile()
	{
		CreateMap<Book, BookDto>()
			.ForMember(dto => dto.ReviewsNumber,
				opt => opt.MapFrom(b => b.Reviews.Count()))
			.ForMember(dto => dto.Rating,
				opt =>
				{
					opt.MapFrom(b => b.Ratings.Count() > 0
						? Math.Round(b.Ratings.Average(r => r.BookRating), 1)
						: 0m);
				})
			.ReverseMap();

		CreateMap<Book, BookDetailsDto>()
			.ForMember(dto => dto.Rating,
				opt =>
				{
					opt.MapFrom(b => b.Ratings.Count() > 0
                        ? Math.Round(b.Ratings.Average(r => r.BookRating), 1)
                        : 0m);
                })
			.ReverseMap();

		CreateMap<Book, BookForCreationDto>().ReverseMap();
	}
}
