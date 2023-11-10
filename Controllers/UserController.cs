using InternetGameShopAPI.Domain;
using InternetGameShopAPI.DTO;
using InternetGameShopAPI.Services;
using Microsoft.AspNetCore.Mvc;
using static InternetGameShopAPI.Services.UserService;

namespace InternetGameShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<User>>> Get()

        //{
        //  //  return Ok(Users);
        //}

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] UserViewModel userviewmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _userService.AddUser(userviewmodel);
                    return Ok(userviewmodel);
                }
                return BadRequest("Invalid input data. User not created.");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while creating the user: " + ex.Message);
            }
        }
        //[HttpPut]
        //public async Task<ActionResult<List<User>>> UpdateUser(User request)
        //{
        //    var user = Users.Find(u => u.UserId == request.UserId);
        //    if (user == null)
        //        return BadRequest("User not found");
        //    user.Username = request.Username;
        //    user.Password = request.Password;
        //    user.Email = request.Email;

        //    return Ok(Users);
        //}

        //[HttpDelete]
        //public async Task<ActionResult<List<User>>> DeleteUser(User request)
        //{
        //    var user = Users.Find(u => u.UserId == request.UserId);
        //    if (user == null)
        //        return BadRequest("User not found");

        //    Users.Remove(user);
        //    return Ok(user);
        //}
    }
}



