using InternetGameShopAPI.Domain;
using InternetGameShopAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InternetGameShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private static List<User> users = new List<User>();

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()

        {
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser([FromBody] UserViewModel userviewmodel)
        {
           
            var game = new Game();
            var dto = new GameDTO()
            {
                Title = new List<string> { game.Title } // Store game titles in a list
            };
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Username = userviewmodel.Username,
                Password = userviewmodel.Password,
                Email = userviewmodel.Email,
                Role = userviewmodel.Role,
                DateOfBirth = userviewmodel.DateOfBirth,
                GamesOwned = userviewmodel.GamesOwned // Store the game titles provided in the request
            };

            users.Add(user);
            return Ok(users);
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User request)
        {
            var user = users.Find(u => u.UserId == request.UserId);
            if (user == null)
                return BadRequest("User not found");
            user.Username = request.Username;
            user.Password = request.Password;
            user.Email = request.Email;

            return Ok(users);
        }

        [HttpDelete]
        public async Task<ActionResult<List<User>>> DeleteUser(User request)
        {
            var user = users.Find(u => u.UserId == request.UserId);
            if (user == null)
                return BadRequest("User not found");

            users.Remove(user);
            return Ok(user);
        }
        public class UserViewModel
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Role { get; set; } = string.Empty;
            public DateTime DateOfBirth { get; set; }
            public List<string> GamesOwned { get; set; } = new List<string>();
        }
    }
}



