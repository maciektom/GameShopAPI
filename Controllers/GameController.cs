using InternetGameShopAPI.Domain;
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
        public ActionResult<List<User>> AddGame(GameViewModel gameviewmodel)
        {
            var game = new Game
            {
                GameId = Guid.NewGuid(),
                Title = gameviewmodel.Title,
                Description = gameviewmodel.Description,
                Developer = gameviewmodel.Developer,
                Publisher = gameviewmodel.Publisher,
                Platform = gameviewmodel.Platform,
                ReleaseDate = gameviewmodel.ReleaseDate,
                Price = gameviewmodel.Price,
                Genre = gameviewmodel.Genre,
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