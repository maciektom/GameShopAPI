using InternetGameShopAPI.Domain.UserAggregate;
using InternetGameShopAPI.Repositories;
using InternetGameShopAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_API.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using static InternetGameShopAPI.Controllers._Users.DeleteUserController;

namespace InternetGameShopAPI.Controllers._Users
{
    public class DeleteUserController : ApiControllerBase
    {
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteUserResult>> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new DeleteUserCommand { UserId = id };
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        public class DeleteUserCommand : IRequest<DeleteUserResult>
        {
            public Guid UserId { get; set; }
        }

        public class DeleteUserResult
        {
            public Guid UserId { get; set; }
            public string Message { get; set; }
        }

        internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResult>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
            {
                _unitOfWork = unitOfWork;
                _userRepository = userRepository;
            }

            public async Task<DeleteUserResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = await _userRepository.GetUserById(request.UserId);
                    if (user != null)
                    {
                        _userRepository.DeleteUser(user.UserId);
                        _unitOfWork.SaveChangesAsync();

                        return new DeleteUserResult
                        {
                            UserId = request.UserId,
                            Message = "User has been deleted."
                        };
                    }
                    else
                    {
                        // Return a specific result for the case when the user is not found
                        return new DeleteUserResult
                        {
                            UserId = request.UserId,
                            Message = "User not found."
                        };
                    }
                }
                catch (Exception)
                {
                    return new DeleteUserResult
                    {
                        Message = "An error has occurred while deleting the user."
                    };
                }
            }
        }
    }
}