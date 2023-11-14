using InternetGameShopAPI.Domain;
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

        [HttpDelete("DeleteUser/{userId}")]
        public async Task<ActionResult<User>> DeleteUser(Guid userId)
        {
            try
            {
                var user = await _userService.GetUserById(userId);

                if (user == null)
                {
                    return NotFound();
                }

                await _userService.DeleteUser(userId);
                return Ok("User deleted.");
            }

            catch (Exception ex)
            {
                return BadRequest("An error occurred while creating the user: " + ex.Message);
            }

        }
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while creating the user: " + ex.Message);
            }
        }
        [HttpPut("changeUserData/{userId}")]
        public async Task<ActionResult<User>> ChangeUserData(Guid userId, [FromBody] UserUpdateModel updatedUserData)
        {
            try
            {
                var succes = await _userService.ChangeUserData(userId, updatedUserData);
                if (succes)
                {
                    return Ok("User data updated succesfylly");
                }
                else
                {
                    return NotFound("User not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while creating the user: " + ex.Message);
            }
        }



        //[HttpGet]
        //public async Task<ActionResult<List<User>>> Get()

        //{
        //  //  return Ok(Users);
        //}        



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



