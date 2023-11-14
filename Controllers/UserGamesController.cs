using InternetGameShopAPI.Domain;
using InternetGameShopAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using static InternetGameShopAPI.Services.GameService;

namespace InternetGameShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserGamesController : Controller
    {
        private readonly IUserGamesService _userGamesService;
        public UserGamesController(IUserGamesService userGamesService)
        {
            _userGamesService = userGamesService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddGameToUser([FromHeader] Guid userid, Guid gameid)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _userGamesService.AddGameToUser(userid, gameid);
                    return Ok($"Added {gameid} to {userid} collection.");
                }
                return BadRequest("Invalid input data. Game not added.");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while creating the user: " + ex.Message);
            }
        }
    }
}
