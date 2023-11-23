using InternetGameShopAPI.Domain.UserAggregate;

namespace InternetGameShopAPI.Domain.GameAggregate
{
    public class Game
    {

        public Guid GameId { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Developer { get; set; }
        public string Platform { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public float Price { get; set; }
        public Genre Genre { get; set; }
        public int Pegi { get; set; }
        //public enum Platform
        //{
        //xbox360,
        //ps5,
        //pc
        //}
    }
}
