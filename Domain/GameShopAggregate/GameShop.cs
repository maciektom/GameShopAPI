namespace InternetGameShopAPI.Domain.GameShopAggregate
{
    public class GameShop
    {
        ICollection<Client> Clients = new List<Client>();
        ICollection<Product> Products = new List<Product>();
        ICollection<GameStudio> GameStudios = new List<GameStudio>();
        public GameShop() { }
    }
}
