using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class BrandRepository : BaseCrudRepository<Brand>, IBrandRepository
{
    public BrandRepository(FoodCalcContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Brand>> GetAllBrands()
    {
        return await GetAll().ToListAsync();
    }

    public async Task<IEnumerable<Brand>> GetAllBrandsByName(string name)
    {
        return await GetAllByCondition(brand => brand.Name!.Equals(name)).ToListAsync();
    }

    public async Task<Brand> GetBrandById(int id)
    {
        return await GetByCondition(brand => brand.Id.Equals(id));
    }

    public async Task CreateBrand(Brand brand)
    {
        await Create(brand);
    }

    public void UpdateBrand(Brand brand)
    {
        Update(brand);
    }

    public void DeleteBrand(Brand brand)
    {
        Delete(brand);
    }
}