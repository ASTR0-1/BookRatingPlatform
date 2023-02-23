using AutoMapper;
using BookRatingPlatform.BLL.DTO;
using BookRatingPlatform.DAL.Models;

namespace BookRatingPlatform.BLL.Mappers;
public class ReviewMappingProfile : Profile
{
	public ReviewMappingProfile()
	{
		CreateMap<Review, ReviewForAddingDto>()
			.ReverseMap();
	}
}
