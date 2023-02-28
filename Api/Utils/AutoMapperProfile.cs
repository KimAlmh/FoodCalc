using Api.Enums;
using Api.Models;
using Api.ViewModels.Brands;
using Api.ViewModels.Food;
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
            .ForMember(dest => dest.Pieces, act => act.Ignore())
            .ForMember(dest => dest.FoodType, act => act.MapFrom(src => FoodEnum(src.Type)));
        
        CreateMap<Food, FoodViewModel>()
            .ForMember(dest => dest.Brand,
                act => act.MapFrom(src => src.Brand!.Name))
            .ForMember(dest => dest.SearchNames,
                act => act.MapFrom(src => src.SearchNames!.Select(s => s.Name)));
        
        CreateMap<SearchName, SearchNameViewModel>();
        CreateMap<PostSearchNameViewModel, SearchName>();

        CreateMap<Piece, PieceViewModel>();
        CreateMap<Piece, SimplePieceViewModel>();

    }

    private static FoodType FoodEnum(string type)
    {
        return type switch
        {
            "G100" => FoodType.Gram,
            "G1" => FoodType.Gram,
            "PD" => FoodType.Product,
            _ => throw new ArgumentException("Invalid type: " + type)
        };
    }
}