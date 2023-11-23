namespace InternetGameShopAPI.Domain.GameAggregate
{

    public class Genre
    {


        public Guid GenreId { get; set; }
        public string Name { get; set; }
        public ICollection<GenreGames> GenreGames { get; set; } = new List<GenreGames>();
        public Genre() { }
        public Genre(Guid genreID, string name)
        {
            GenreId = genreID;
            Name = name;
        }
    }
}
