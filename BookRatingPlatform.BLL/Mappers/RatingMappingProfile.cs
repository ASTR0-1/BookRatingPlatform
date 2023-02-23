using AutoMapper;
using BookRatingPlatform.BLL.DTO;
using BookRatingPlatform.DAL.Models;

namespace BookRatingPlatform.BLL.Mappers;

public class RatingMappingProfile : Profile
{
    public RatingMappingProfile()
    {
        CreateMap<Rating, RatingForAddingDto>()
            .ReverseMap();
    }
}
