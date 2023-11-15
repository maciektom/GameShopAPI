namespace InternetGameShopAPI.Domain
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public ICollection<UserGames> GamesOwned { get; set; } = new List<UserGames>();
        public void AddGameToUser(UserGames game)
        {
            GamesOwned.Add(game);
        }
    }
}

