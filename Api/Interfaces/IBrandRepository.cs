using Api.Models;
using Api.ViewModels.Brands;

namespace Api.Interfaces;

public interface IBrandRepository
{
    Task<bool> SaveAllAsync();
    Task<BrandViewModel> CreateBrandAsync(PostBrandViewModel model);
    Task<BrandViewModel> GetBrandAsync(int id);
    Task<List<BrandViewModel>> ListBrandAsync();
    Task DeleteBrandAsync(int id);
    Task<Brand> FindByNameAsync(string? brandName);
}