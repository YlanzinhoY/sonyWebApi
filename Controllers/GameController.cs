using Microsoft.AspNetCore.Mvc;
using SonyGamesWebAPI.Model;
using SonyGamesWebAPI.Repositories;

namespace SonyGamesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private readonly IGameRepository _gameRepository;
        public GameController(IGameRepository gameRepository) 
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Game>> GetGames() => await _gameRepository.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGames(int id) => await _gameRepository.Get(id);

        [HttpPost]
        public async Task<ActionResult<Game>> PostGames([FromBody] Game game)
        {
            var newGame = await _gameRepository.Create(game);
            return CreatedAtAction(nameof(GetGames), new { id = newGame.Id }, newGame);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var gameToDelete = await _gameRepository.Get(id);

            if (gameToDelete == null)
                return NotFound();

            await _gameRepository.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Game>> Put(int id, [FromBody] Game game)
        {
            if(id != game.Id)
            {
                return BadRequest();
            }

            var updatedGame = await _gameRepository.Update(game);

            if(updatedGame == null)
            {
                return NotFound();
            }

            return updatedGame;

        }

    }
}
