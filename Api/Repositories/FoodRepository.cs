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

    public async Task<Food?> GetFoodById(int id)
    {
        return await GetByCondition(food => food.Id.Equals(id)) ?? throw new KeyNotFoundException("No food with that id");
    }

    public async Task<Food?> GetFoodByNameAndBrandId(string name, int brandId)
    {
        return await GetByCondition(food => food.Name!.Equals(name) && food.BrandId.Equals(brandId));
    }

    public async Task CreateFood(Food food)
    {
        await Create(food);
    }

    public async Task<bool> CheckIfExistsByNameAndBrandId(string name, int brandId)
    {
        return await CheckIfExists(food => food.Name == name && food.BrandId == brandId);
    }

    public void UpdateFood(Food food)
    {
        Update(food);
    }

    public void DeleteFood(Food food)
    {
        Delete(food);
    }
}