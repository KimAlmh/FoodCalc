using Api.Models;
using Api.ViewModels.Brands;
using Api.ViewModels.FoodPerGrams;
using Api.ViewModels.Pieces;
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
            .ForMember(dest => dest.Brand,
                act => act.MapFrom(src => src.Brand!.Name))
            .ForMember(dest => dest.Pieces,
                act => act.MapFrom(src => src.Pieces!.Select(s => s.Weight)))
            .ForMember(dest => dest.SearchNames,
                act => act.MapFrom(src => src.SearchNames!.Select(s => s.Name)));


        CreateMap<SearchName, SearchNameViewModel>();
        CreateMap<PostSearchNameViewModel, SearchName>();

        // CreateMap<PostFoodPerPieceViewModel, FoodPerPiece>();
        CreateMap<Piece, PieceViewModel>();
        // CreateMap<Food, PieceViewModel>();
    }
}