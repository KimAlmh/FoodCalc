using Api.Interfaces;
using Api.Models;
using Api.ViewModels.Brands;
using Moq;

namespace Api.Tests.Mocks;

public class MockRepository
{
    public static Mock<IBrandRepository> GetMock()
    {
        var mock = new Mock<IBrandRepository>();
        var brands = new List<Brand>()
        {
            new(){
            Id = 234,
            Name = "OLW",
            Description = "Maker of snacks"
        }};

        // mock.Setup(m => m.ListBrandsAsync()).Returns(() => brands);
        // mock.Setup(m => m.FindByNameAsync(It.IsAny<string>()))
        //     .Returns((string name) => brands.FirstOrDefault(b => b.Name == name));
        // mock.Setup(m => m.CreateBrandAsync(It.IsAny<PostBrandViewModel>())).Callback(() => { return; });
        // mock.Setup(m => m.DeleteBrandAsync(It.IsAny<int>())).Callback(() => { return; });
        // mock.Setup(m => m.SaveAllAsync()).Callback(() => { return; });
        
        return mock;
    }
}