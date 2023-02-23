namespace Api.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        int id = 1;
        Assert.That(id, Is.EqualTo(2));
    }
}