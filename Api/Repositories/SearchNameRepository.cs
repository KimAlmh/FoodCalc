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

    public async Task<IEnumerable<SearchName>> GetAllSearchNames()
    {
        return await GetAll().ToListAsync();
    }


    public async Task<SearchName?> GetSearchNameById(int id)
    {
        return await GetAllByCondition(searchName => searchName.Id.Equals(id)).FirstOrDefaultAsync() ??
               throw new KeyNotFoundException("No search name with that id");
    }

    public async Task<SearchName?> GetSearchNameByNameAndFoodId(int id, string name)
    {
        return await GetAllByCondition(searchName => searchName.Name!.Equals(name) && searchName.FoodId.Equals(id))
            .FirstOrDefaultAsync();
    }

    public async Task CreateAllSearchNames(List<SearchName> searchNames)
    {
        foreach (var searchName in searchNames) await CreateSearchName(searchName);
    }

    public async Task CreateSearchName(SearchName searchName)
    {
        await Create(searchName);
    }


    public void UpdateSearchName(SearchName searchName)
    {
        Update(searchName);
    }


    public void DeleteSearchName(SearchName searchName)
    {
        Delete(searchName);
    }

    public async Task<IEnumerable<SearchName>> GetAllSearchNamesByName(string name)
    {
        return await GetAllByCondition(searchName => searchName.Name!.Equals(name)).ToListAsync();
    }
}