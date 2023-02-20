using Api.Models;
using Api.ViewModels.Brands;

namespace Api.Interfaces;

public interface IBrandRepository
{
    public Task<bool> SaveAllAsync();
    public Task<Brand> CreateBrandAsync(PostBrandViewModel model);
    public Task<BrandViewModel> GetBrandAsync(int id);
    public Task<List<BrandViewModel>> ListBrandAsync();
    public Task DeleteBrandAsync(int id);
}