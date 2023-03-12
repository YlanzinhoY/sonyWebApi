using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SonyGamesWebAPI.Model;
using SonyGamesWebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<GameContext>(x => x.UseSqlite("Data source=games.db"));
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "GameApi", Version = "v1" }));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SonyGamesApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
