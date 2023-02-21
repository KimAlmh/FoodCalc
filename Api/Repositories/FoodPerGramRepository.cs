using Api.Data;
using Api.Enums;
using Api.Interfaces;
using Api.Models;
using Api.ViewModels.FoodPerGrams;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class FoodPerGramRepository : IFoodPerGramRepository
{
    private readonly FoodCalcContext _context;
    private readonly IMapper _mapper;
    private readonly IBrandRepository _brandRepository;

    public FoodPerGramRepository(FoodCalcContext context, IMapper mapper, IBrandRepository brandRepository)
    {
        _context = context;
        _mapper = mapper;
        _brandRepository = brandRepository;
    }

    public async Task<bool> SaveAllAsync() => await _context.SaveChangesAsync() > 0;

    public async Task<FoodPerGram> CreateFoodPerGramAsync(PostFoodPerGramViewModel model)
    {
        var brand = await _brandRepository.FindByNameAsync(model.Brand);
        model = (model.GramType == GramType.G100) ? DivideBy100(model) : model;
        var foodPerGram = _mapper.Map<FoodPerGram>(model);
        foodPerGram.Brand = brand;
        await _context.FoodPerGrams.AddAsync(foodPerGram);
        return foodPerGram;
    }

    public async Task<FoodPerGramViewModel> GetFoodPerGramAsync(int id)
    {
        var foodPerGram = await _context.FoodPerGrams
                              .Include(i => i.Brand)
                              .FirstOrDefaultAsync(f => f.Id == id) ??
                          throw new ArgumentException("No food per gram with that id: " + id);
        return MultiplyBy100(_mapper.Map<FoodPerGramViewModel>(foodPerGram));
    }

    public async Task<List<FoodPerGramViewModel>> ListFoodPerGramsAsync() =>
        await _context.FoodPerGrams.Include(i => i.Brand).Select(s => _mapper.Map<FoodPerGramViewModel>(s))
            .ToListAsync();


    public async Task DeleteFoodPerGramAsync(int id)
    {
        var foodPerGram = await _context.FoodPerGrams.FindAsync(id) ??
                          throw new ArgumentException("No food per gram with id: " + id);
        _context.Remove(foodPerGram);
        await SaveAllAsync();
    }

    private FoodPerGramViewModel MultiplyBy100(FoodPerGramViewModel model)
    {
        model.Kcal = Math.Round(model.Kcal * 100, 3);
        model.Kj = Math.Round(model.Kj * 100, 3);
        model.Carbohydrate = Math.Round(model.Carbohydrate * 100, 3);
        model.Fat = Math.Round(model.Fat * 100, 3);
        model.Protein = Math.Round(model.Protein * 100, 3);
        model.Sugar = Math.Round(model.Sugar * 100, 3);
        model.Fibre = Math.Round(model.Fibre * 100, 3);
        model.SaturatedFat = Math.Round(model.SaturatedFat * 100, 3);
        model.Salt = Math.Round(model.Salt * 100, 3);
        return model;
    }

    private PostFoodPerGramViewModel DivideBy100(PostFoodPerGramViewModel model)
    {
        model.Kcal /= 100;
        model.Kj /= 100;
        model.Carbohydrate /= 100;
        model.Fat /= 100;
        model.Protein /= 100;
        model.Sugar /= 100;
        model.Fibre /= 100;
        model.SaturatedFat /= 100;
        model.Salt /= 100;
        return model;
    }
}