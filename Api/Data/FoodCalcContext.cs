using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class FoodCalcContext : DbContext
{
    public FoodCalcContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<FoodPerGram> FoodPerGrams { get; set; } = null!;
    public DbSet<FoodPerPiece> FoodPerPieces { get; set; } = null!;
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<SearchName> SearchNames { get; set; } = null!;
}