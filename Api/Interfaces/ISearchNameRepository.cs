using Api.Models;

namespace Api.Interfaces;

public interface ISearchNameRepository
{
    Task<IEnumerable<SearchName>> GetAllSearchNames();
    Task<SearchName> GetSearchNameById(int id);
    Task CreateSearchName(SearchName searchName);
    void UpdateSearchName(SearchName searchName);
    void DeleteSearchName(SearchName searchName);
}