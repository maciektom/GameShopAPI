namespace InternetGameShopAPI.Domain.GameShopAggregate
{
    public class GameStudio
    {
        public Guid GameStudioId { get; private set; }
        public string Name { get; private set; }
        public GameStudio(Guid gameStudioId, string name)
        {
            GameStudioId = gameStudioId;
            Name = name;
        }
    }
}