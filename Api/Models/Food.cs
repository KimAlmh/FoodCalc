namespace Api.Models;

public abstract class Food
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public Brand? Brand { get; set; }
    public double Kcal { get; set; }
    public double Kj { get; set; }
    public double Carbohydrate { get; set; }
    public double Fat { get; set; }
    public double Protein { get; set; }
    public double Sugar { get; set; }
    public double Fibre { get; set; }
    public double SaturatedFat { get; set; }
    public double Salt { get; set; }
    
}