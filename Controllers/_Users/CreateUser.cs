using InternetGameShopAPI.Domain.UserAggregate;
using InternetGameShopAPI.Repositories;
using InternetGameShopAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_API.Common;

namespace InternetGameShopAPI.Controllers._Users
{
    public class CreateUserController : ApiControllerBase
    {
        [HttpPost()]
        public async Task<ActionResult<CreateUserResult>> Create(CreateUserCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }

    public class CreateUserCommand : IRequest<CreateUserResult>
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
            public DateTime DateOfBirth { get; set; }
        }

    public class CreateUserResult 
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
            public DateTime DateOfBirth { get; set; }

        }
        internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResult>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUnitOfWork _unitOfWork;
            public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
            {
                _userRepository = userRepository;
                _unitOfWork = unitOfWork;
            }
            public async Task<CreateUserResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var entity = new User(request.Username, request.Password, request.Email, request.Role, request.DateOfBirth);
                await _userRepository.AddUser(entity);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(new CreateUserResult
                {
                    Username = request.Username,
                    Password = request.Password,
                    Email = request.Email,
                    Role = request.Role,
                    DateOfBirth = request.DateOfBirth
                });
            }
        }
    }
}
