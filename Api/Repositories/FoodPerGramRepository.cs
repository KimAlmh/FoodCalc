﻿using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class FoodPerGramRepository : BaseCrudRepository<FoodPerGram>, IFoodPerGramRepository
{
    public FoodPerGramRepository(FoodCalcContext context) : base(context)
    {
    }

    public async Task<IEnumerable<FoodPerGram>> GetAllFoodPerGrams()
    {
        return await GetAll().Include(food => food.Brand).ToListAsync();
    }

    public async Task<IEnumerable<FoodPerGram>> GetAllFoodPerGramsByName(string name)
    {
        return await GetAllByCondition(foodPerGram => foodPerGram.Name!.Equals(name))
            .Include(food => food.Brand).ToListAsync();
    }

    public async Task<FoodPerGram> GetFoodPerGramById(int id)
    {
        return await GetByCondition(foodPerGram => foodPerGram.Id.Equals(id));
    }

    public async Task CreateFoodPerGram(FoodPerGram foodPerGram)
    {
        await Create(foodPerGram);
    }

    public void UpdateFoodPerGram(FoodPerGram foodPerGram)
    {
        Update(foodPerGram);
    }

    public void DeleteFoodPerGram(FoodPerGram foodPerGram)
    {
        Delete(foodPerGram);
    }
}