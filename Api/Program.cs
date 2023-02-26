using System.Text.Json.Serialization;
using Api.Data;
using Api.Exceptions;
using Api.Interfaces;
using Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["FoodCalcDb"];

builder.Services.AddSqlServer<FoodCalcContext>(connectionString);
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// app.UseMiddleware<ErrorHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();