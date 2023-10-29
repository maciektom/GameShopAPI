using InternetGameShopAPI.Domain;

namespace InternetGameShopAPI.Domain
{
    public class Game
    {

        public Guid GameId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Platform { get; set; }
        public string ReleaseDate { get; set; } 
        public float Price { get; set; }
        public string Genre { get; set; }
        public Game(Guid gameId, string title, string description, string developer, string publisher, string platform, string releaseDate, float price, string genre)
        {
            GameId = gameId;
            Title = title;
            Description = description;
            Developer = developer;
            Publisher = publisher;
            Platform = platform;
            ReleaseDate = releaseDate;
            Price = price;
            Genre = genre;
        }
    }
}
