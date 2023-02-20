using Api.Data;
using Api.Interfaces;
using Api.Models;
using Api.ViewModels.Brands;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly FoodCalcContext _context;
    private readonly IMapper _mapper;

    public BrandRepository(FoodCalcContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> SaveAllAsync() => await _context.SaveChangesAsync() > 0;

    public async Task<BrandViewModel> CreateBrandAsync(PostBrandViewModel model)
    {
        var brand = _mapper.Map<Brand>(model);
        await _context.Brands.AddAsync(brand);
        return _mapper.Map<BrandViewModel>(brand);
    }

    public async Task<BrandViewModel> GetBrandAsync(int id)
    {
        var brand = await _context.Brands
            .FirstOrDefaultAsync(f => f.Id == id) ?? throw new ArgumentException("No brand with that id.");
        return _mapper.Map<BrandViewModel>(brand);
    }

    public async Task<List<BrandViewModel>> ListBrandAsync() => 
        await _context.Brands.Select(s => _mapper.Map<BrandViewModel>(s)).ToListAsync();
    
    public async Task DeleteBrandAsync(int id)
    {
        var brand = await _context.Brands.FindAsync(id) ??
                          throw new ArgumentException("No brand with id: " + id);
        _context.Remove(brand);
        await SaveAllAsync();
    }

    public async Task<Brand> FindByNameAsync(string? brandName)
    {
        return await _context.Brands.FirstOrDefaultAsync(f => f.Name == brandName) 
               ?? throw new ArgumentException("No brand with name: " + brandName);
    }
}