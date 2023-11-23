//using InternetGameShopAPI.Domain.UserAggregate;
//using InternetGameShopAPI.DTO;
//using InternetGameShopAPI.Repositories;
//using InternetGameShopAPI.Services;
//using Microsoft.AspNetCore.Mvc;
//using static InternetGameShopAPI.Repositories.UserRepository;

//namespace InternetGameShopAPI.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class UserController : Controller
//    {

//        private readonly IUserRepository _userRepository;
//        public UserController(IUserRepository userService)
//        {
//            _userRepository = userService;
//        }

        
//        [HttpPost]
//        public async Task<ActionResult<User>> AddUser([FromBody] CreateUserDTO user)
//        {
//            try
//            {

//                if (ModelState.IsValid)
//                {
//                    await _userRepository.AddUser(user);
//                    return Ok(user);
//                }
//                return BadRequest("Invalid input data. User not created.");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest("An error occurred while creating the user: " + ex.Message);
//            }
//        }

//        [HttpDelete("DeleteUser/{userId}")]
//        public async Task<ActionResult<User>> DeleteUser(Guid userId)
//        {
//            try
//            {
//                var user = await _userRepository.GetUserById(userId);

//                if (user == null)
//                {
//                    return NotFound();
//                }

//                await _userRepository.DeleteUser(userId);
//                return Ok("User deleted.");
//            }

//            catch (Exception ex)
//            {
//                return BadRequest("An error occurred while creating the user: " + ex.Message);
//            }

//        }
//        [HttpGet("GetAllUsers")]
//        public async Task<ActionResult<List<User>>> GetAllUsers()
//        {
//            try
//            {
//                var users = await _userRepository.GetAllUsers();
//                return Ok(users);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest("An error occurred while creating the user: " + ex.Message);
//            }
//        }
//        [HttpPut("changeUserData/{userId}")]
//        public async Task<ActionResult<User>> UpdateUser(Guid userId, [FromBody]UpdateUserDTO updatedUserData)
//        {
//                var success = await _userRepository.ChangeUserData(userId, updatedUserData);
//                 return Ok(success);
//        }




//        //[HttpGet]
//        //public async Task<ActionResult<List<User>>> Get()

//        //{
//        //  //  return Ok(Users);
//        //}        



//        //[HttpPut]
//        //public async Task<ActionResult<List<User>>> UpdateUser(User request)
//        //{
//        //    var user = Users.Find(u => u.UserId == request.UserId);
//        //    if (user == null)
//        //        return BadRequest("User not found");
//        //    user.Username = request.Username;
//        //    user.Password = request.Password;
//        //    user.Email = request.Email;

//        //    return Ok(Users);
//        //}

//        //[HttpDelete]
//        //public async Task<ActionResult<List<User>>> DeleteUser(User request)
//        //{
//        //    var user = Users.Find(u => u.UserId == request.UserId);
//        //    if (user == null)
//        //        return BadRequest("User not found");

//        //    Users.Remove(user);
//        //    return Ok(user);
//        //}
//    }
//}



