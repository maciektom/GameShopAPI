namespace InternetGameShopAPI.Domain
{
    public class Game
    {

        public Guid GameId { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Developer { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public float Price { get; set; }
        public string Genre { get; set; } = string.Empty;
        public Guid UserId { get; }
        public User User { get; }
        //public enum Platform
        //{
        //xbox360,
        //ps5,
        //pc
        //}
    }
}
