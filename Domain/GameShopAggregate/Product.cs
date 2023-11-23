using InternetGameShopAPI.Domain.UserAggregate;

namespace InternetGameShopAPI.Domain.GameShopAggregate
{
    public class Product
    {
        public Guid ProductId { get; private set; }
        public string Title { get; private set; } 
        public string Description { get; private set; } 
        public string GameStudio { get; private set; }
        public string Platform { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public float Price { get; private set; }
        public string Genre { get; private set; }
        public int Pegi { get; private set; }
    }
}
