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

        CreateMap<PostFoodPerGramViewModel, FoodPerGram>()
            .ForMember(dest => dest.SearchNames, act => act.Ignore())
            .ForMember(dest => dest.FoodPerPieces, act => act.Ignore());
        CreateMap<FoodPerGram, FoodPerGramViewModel>()
            .ForMember(dest => dest.PieceWeights,
                act => act.MapFrom(src => src.FoodPerPieces));

        CreateMap<SearchName, SearchNameViewModel>();
        CreateMap<PostSearchNameViewModel, SearchName>();

        // CreateMap<PostFoodPerPieceViewModel, FoodPerPiece>();
        CreateMap<FoodPerPiece, FoodPerPieceViewModel>();
    }
}