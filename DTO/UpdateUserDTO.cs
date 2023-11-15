using Azure.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InternetGameShopAPI.DTO
{
    public class UpdateUserDTO
    {
        public Guid UserId { get;  }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
