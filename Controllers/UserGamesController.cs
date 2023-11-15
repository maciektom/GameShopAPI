using InternetGameShopAPI.Domain;
using InternetGameShopAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
                    await _userGamesService.AddGameToUser(userid, gameid);
                    return Ok($"Added {gameid} to {userid} collection.");
             }
        }
    }
