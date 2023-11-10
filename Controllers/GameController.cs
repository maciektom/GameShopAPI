using InternetGameShopAPI.Domain;
using InternetGameShopAPI.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using static InternetGameShopAPI.Controllers.UserController;

namespace InternetGameShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private static List<Game> games = new List<Game>();

        [HttpGet]
        public async Task<ActionResult<List<Game>>> Get()

        {
            return Ok(games);
        }

        [HttpPost]
        public ActionResult<List<User>> AddGame(GameViewModel gameViewModel)
        {
            var game = new Game
            {
                GameId = Guid.NewGuid(),
                Title = gameViewModel.Title,
                Description = gameViewModel.Description,
                Developer = gameViewModel.Developer,
                Publisher = gameViewModel.Publisher,
                Platform = gameViewModel.Platform,
                ReleaseDate = gameViewModel.ReleaseDate,
                Price = gameViewModel.Price,
                Genre = gameViewModel.Genre,
            };
            games.Add(game);
            return Ok(games);

        }
        public class GameViewModel
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Developer { get; set; }
            public string Publisher { get; set; }
            public string Platform { get; set; }
            public DateTime ReleaseDate { get; set; }
            public float Price { get; set; }
            public string Genre { get; set; }
        }

    }
}