using Api.Data;
using Api.Interfaces;
using Api.Models;
using Api.ViewModels.Brands;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class BrandRepository : BaseCrudRepository<Brand>, IBrandRepository
{
    public BrandRepository(FoodCalcContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Brand>> GetAllBrands() => await GetAll().ToListAsync();
    public async Task<List<Brand>> GetAllBrandsByName(string name) => await GetAllByCondition(brand => brand.Name!.Equals(name)).ToListAsync();
    public async Task<Brand> GetBrandById(int id) => await GetAllByCondition(brand => brand.Id.Equals(id)).SingleAsync();
    public async Task<Brand> GetBrandByName(string name) => await GetAllByCondition(brand => brand.Name!.Equals(name)).SingleAsync();
    public async Task CreateBrand(Brand brand) => await Create(brand);
    public void UpdateBrand(Brand brand) => Update(brand);
    public void DeleteBrand(Brand brand) => Delete(brand);
    public async Task<bool> Save() => await SaveAll();
}