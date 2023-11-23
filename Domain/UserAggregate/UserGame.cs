using InternetGameShopAPI.Domain.GameAggregate;

namespace InternetGameShopAPI.Domain.UserAggregate
{
    public class UserGame
    {
        public UserGame() { }

        public UserGame(Guid user_id, Guid game_id, string title)
        {
            User_id = user_id;
            Game_id = game_id;
            Title = title;
        }

        public Guid User_id { get; set; }
        public Guid Game_id { get; set; }
        public string Title { get; set; }
        public User User { get; }
        public Game Game { get; }

    }
}
