using Api.Models;

namespace Api.Interfaces;

public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetAllBrands();
    Task<IEnumerable<Brand>> GetAllBrandsByName(string name);
    Task<Brand?> GetBrandById(int id);
    Task CreateBrand(Brand brand);
    void UpdateBrand(Brand? brand);
    void DeleteBrand(Brand? brand);
}