namespace InternetGameShopAPI.Domain.UserAggregate
{

    public class User
    {
        public Guid UserId { get; private set; } = Guid.NewGuid();
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; private set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public ICollection<UserGame> UserGames = new List<UserGame>();
        public ICollection<UserReview> UserReviews = new List<UserReview>();

       

        public User(string username, string password, string email, string role, DateTime dateOfBirth)
        {
            Username = username;
            Password = password;    
            Email = email;
            Role = role;
            DateOfBirth = dateOfBirth;
        }
    }
    //   public void AddGameToUser(UserGames game)
    //       {
    //           GamesOwned.Add(game);  
    //       }
    //   }
}

