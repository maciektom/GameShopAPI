using InternetGameShopAPI.Domain.GameAggregate;
using InternetGameShopAPI.Domain.UserAggregate;
using InternetGameShopAPI.Infrastructure;
using InternetGameShopAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

using static InternetGameShopAPI.Services.GameService;
namespace InternetGameShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<ActionResult<Game>> AddGame([FromBody] GameViewModel gameViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _gameService.AddGame(gameViewModel);
                    return Ok(gameViewModel);
                }
                return BadRequest("Invalid input data. User not created.");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while creating the user: " + ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<User>> DeleteGame(Guid gameId)
        {
            try
            {
                var user = await _gameService.GetGameById(gameId);

                if (user == null)
                {
                    return NotFound();
                }

                await _gameService.DeleteGame(gameId);
                return Ok("Game deleted.");
            }

            catch (Exception ex)
            {
                return BadRequest("An error occurred while creating the user: " + ex.Message);
            }

        }
        [HttpGet("GetAllGames")]
        public async Task<ActionResult<ICollection<Game>>> GetGames()
        {
            try
            {
                var games = await _gameService.GetAllGames();
                return Ok(games);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while creating the user: " + ex.Message);
            }

        }
    }
}


//        [HttpGet]
//        public async Task<ActionResult<List<Game>>> Get()

//        {
//            return Ok(games);
//        }

//        [HttpPost]
//        public ActionResult<List<User>> AddGame(GameViewModel gameViewModel)
//        {
//            var game = new Game
//            {
//                GameId = Guid.NewGuid(),
//                Title = gameViewModel.Title,
//                Description = gameViewModel.Description,
//                Developer = gameViewModel.Developer,
//                Publisher = gameViewModel.Publisher,
//                Platform = gameViewModel.Platform,
//                ReleaseDate = gameViewModel.ReleaseDate,
//                Price = gameViewModel.Price,
//                Genre = gameViewModel.Genre,
//            };
//            games.Add(game);
//            return Ok(games);

//        }
//        public class GameViewModel
//        {
//            public string Title { get; set; }
//            public string Description { get; set; }
//            public string Developer { get; set; }
//            public string Publisher { get; set; }
//            public string Platform { get; set; }
//            public DateTime ReleaseDate { get; set; }
//            public float Price { get; set; }
//            public string Genre { get; set; }
//        }

//    }
//}