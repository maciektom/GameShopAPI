using Azure.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InternetGameShopAPI.DTO
{
    public class UpdateUserDTO
    {
        public string UpdatedUsername { get; set; }
        public string UpdatedPassword { get; set; }
        public string UpdatedEmail { get; set; }
    }
}
