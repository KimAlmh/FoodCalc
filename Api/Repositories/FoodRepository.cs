using Api.Data;
using Api.Exceptions;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class FoodRepository : BaseCrudRepository<Food>, IFoodRepository
{
    public FoodRepository(FoodCalcContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Food?>> GetAllFoods()
    {
        return await GetAll()
            .Include(food => food.Brand)
            .Include(food => food.Pieces)
            .Include(food => food.SearchNames)
            .ToListAsync();
    }

    public async Task<IEnumerable<Food>> GetAllFoodsByName(string name)
    {
        return await GetAllByCondition(food => food.Name!.Equals(name))
            .Include(food => food.Brand)
            .Include(food => food.Pieces)
            .Include(food => food.SearchNames)
            .ToListAsync();
    }

    public async Task<Food> GetFoodById(int id)
    {
        return await GetAllByCondition(food => food.Id.Equals(id))
            .Include(i => i.Brand)
            .Include(f => f.SearchNames)
            .Include(f => f.Pieces)
            .FirstOrDefaultAsync() ?? throw new FoodNotFoundException("No food with that id");
    }

    public async Task CreateFood(Food food)
    {
        await Create(food);
    }

    public void UpdateFood(Food food)
    {
        Update(food);
    }

    public void DeleteFood(Food food)
    {
        Delete(food);
    }

    public async Task CheckConstraint(string name, int brandId)
    {
        var food = await GetFoodByNameAndBrandId(name, brandId);
        if (food != null) throw new UniqueConstraintException("Food with that brand and name already exists", food.Id);
    }

    public async Task<Food?> GetFoodByNameAndBrandId(string name, int brandId)
    {
        return await GetAllByCondition(food => food.Name!.Equals(name) && food.BrandId.Equals(brandId))
            .FirstOrDefaultAsync();
    }
}