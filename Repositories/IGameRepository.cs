using SonyGamesWebAPI.Model;

namespace SonyGamesWebAPI.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> Get();
        Task<Game> Get(int id);
        Task<Game> Create(Game game);
        Task<Game> Update(Game game);
        Task Delete(int id);


    }
}
