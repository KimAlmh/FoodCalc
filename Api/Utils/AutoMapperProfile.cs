using Api.Models;
using Api.ViewModels.Brands;
using Api.ViewModels.FoodPerGrams;
using Api.ViewModels.FoodPerPieces;
using Api.ViewModels.SearchNames;
using AutoMapper;

namespace Api.Utils;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<PostBrandViewModel, Brand>();
        CreateMap<Brand, BrandViewModel>();

        CreateMap<PostFoodViewModel, Food>()
            .ForMember(dest => dest.SearchNames, act => act.Ignore())
            .ForMember(dest => dest.Pieces, act => act.Ignore());
        CreateMap<Food, FoodViewModel>()
            .ForMember(dest => dest.Pieces,
                act => act.MapFrom(src => src.Pieces));

        CreateMap<SearchName, SearchNameViewModel>();
        CreateMap<PostSearchNameViewModel, SearchName>();

        // CreateMap<PostFoodPerPieceViewModel, FoodPerPiece>();
        CreateMap<Piece, PieceViewModel>();
    }
}