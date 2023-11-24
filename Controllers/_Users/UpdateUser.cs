using InternetGameShopAPI.Domain.UserAggregate;
using InternetGameShopAPI.Repositories;
using InternetGameShopAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Project_API.Common;
using System.Text.Json.Serialization;

namespace InternetGameShopAPI.Controllers._Users
{
    public class UpdateUserController : ApiControllerBase
    {
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateUserResult>> Update(Guid id, [FromBody] UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var command = new UpdateUserCommand
            {
                UserId = id,
                NewUsername = request.NewUsername,
                NewPassword = request.NewPassword,
                NewEmail = request.NewEmail
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        public class UpdateUserCommand : IRequest<UpdateUserResult>
        {
            public Guid UserId { get; set; }
            public string NewUsername { get; set; }
            public string NewPassword { get; set; }
            public string NewEmail { get; set; }
        }
        public class UpdateUserRequest
        {
            public string NewUsername { get; set; }
            public string NewPassword { get; set; }
            public string NewEmail { get; set; }
        }
        public class UpdateUserResult
        {
            public Guid UserId { get; set; }
            public string Message { get; set; }
        }

        internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResult>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUnitOfWork _unitOfWork;

            public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
            {
                _unitOfWork = unitOfWork;
                _userRepository = userRepository;
            }

            public async Task<UpdateUserResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = await _userRepository.GetUserById(request.UserId);
                    if (user != null)
                    {
                        user.Username = request.NewUsername;
                        user.Password = request.NewPassword;
                        user.Email = request.NewEmail;
                        await _userRepository.UpdateUser(user.UserId);
                        await _unitOfWork.SaveChangesAsync();  // Use await here

                        // Set the UserId property in the result to the correct value
                        return new UpdateUserResult
                        {
                            UserId = user.UserId,
                            Message = "User has been updated."
                        };
                    }
                    else
                    {
                        return new UpdateUserResult
                        {
                            // Handle the case when the user is not found
                            UserId = request.UserId,
                            Message = "User not found."
                        };
                    }
                }
                catch (Exception)
                {
                    return new UpdateUserResult
                    {
                        // Handle the case when an error occurs
                        UserId = request.UserId,
                        Message = "gej"
                    };
                }
            }
        }
    }
}