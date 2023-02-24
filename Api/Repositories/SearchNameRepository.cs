using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class SearchNameRepository : BaseCrudRepository<SearchName>, ISearchNameRepository
{
    public SearchNameRepository(FoodCalcContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<SearchName>> GetAllSearchNames() => await GetAll().ToListAsync();
    
    public async Task<IEnumerable<SearchName>> GetAllSearchNamesByName(string name) => 
        await GetAllByCondition(searchName => searchName.Name!.Equals(name)).ToListAsync();
    

    public async Task<SearchName?> GetSearchNameById(int id) => await GetByCondition(searchName => searchName.Id.Equals(id));
    public async Task CreateAllSearchNames(List<SearchName> searchNames)
    {
        foreach (var searchName in searchNames)
        { 
            await CreateSearchName(searchName);
        }
    }
    
    public async Task CreateSearchName(SearchName searchName) => await Create(searchName);
    

    public void UpdateSearchName(SearchName searchName) => Update(searchName);
    

    public void DeleteSearchName(SearchName searchName) => Delete(searchName);
}