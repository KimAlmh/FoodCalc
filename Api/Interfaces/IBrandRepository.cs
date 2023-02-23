using Api.Models;
using Api.ViewModels.Brands;

namespace Api.Interfaces;

public interface IBrandRepository
{
    // Task<bool> SaveAllAsync();
    // Task<Brand> CreateBrandAsync(PostBrandViewModel model);
    // Task<Brand> GetBrandAsync(int id);
    // Task<IEnumerable<Brand>> ListBrandsAsync();
    // Task DeleteBrandAsync(int id);
    // Task<Brand> FindByNameAsync(string? brandName);
    Task<IEnumerable<Brand>> GetAllBrands();
    Task<List<Brand>> GetAllBrandsByName(string name);
    Task<Brand> GetBrandById(int id);
    Task<Brand> GetBrandByName(string name);
    Task CreateBrand(Brand brand);
    void UpdateBrand(Brand brand);
    void DeleteBrand(Brand brand);

}