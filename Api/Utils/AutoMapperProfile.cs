using Api.Models;
using Api.ViewModels.Brands;
using Api.ViewModels.FoodPerGrams;
using Api.ViewModels.FoodPerPieces;
using AutoMapper;

namespace Api.Utils;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<PostBrandViewModel, Brand>();
        CreateMap<Brand, BrandViewModel>();

        CreateMap<PostFoodPerGramViewModel, FoodPerGram>();
        CreateMap<FoodPerGram, FoodPerGramViewModel>();

        CreateMap<PostFoodPerPieceViewModel, FoodPerPiece>();
        CreateMap<FoodPerPiece, FoodPerPieceViewModel>();
    }
}