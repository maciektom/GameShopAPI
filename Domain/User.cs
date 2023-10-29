using InternetGameShopAPI.Domain;

namespace InternetGameShopAPI.Domain
{
    public class User
    {
        public Guid UserId { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string Role { get; set; }
        public ICollection<Game> GamesOwned { get; set; }
        public User(Guid id, string username, string password, string email, DateTime dateofbirth, string role, ICollection<Game> gamesOwned)
        {
            UserId = id;
            Username = username;
            Password = password;
            Email = email;
            Dateofbirth = dateofbirth;
            Role = role;
            GamesOwned = gamesOwned;
        }
    }
}

