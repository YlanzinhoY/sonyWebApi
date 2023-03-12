using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace SonyGamesWebAPI.Model
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Game> Games { get; set; }
    }
}
