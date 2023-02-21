using Api;
using Api.Data;
using Api.Helpers;
using Api.Interfaces;
using Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

AppData.Configuration = builder.Configuration;
var connectionString = AppData.Configuration["FoodCalcDb"];

// Add services to the container.
builder.Services.AddSqlServer<FoodCalcContext>(connectionString);

builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IFoodPerGramRepository, FoodPerGramRepository>();
builder.Services.AddScoped<IFoodPerPieceRepository, FoodPerPieceRepository>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();