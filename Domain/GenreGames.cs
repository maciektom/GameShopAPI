namespace InternetGameShopAPI.Domain
{
    public class GenreGames
    {
        public GenreGames() { }

        public GenreGames(Guid genre_id, Guid game_id, string name, string title)
        {
            Name = name;
            Title = title;
        }

        public Guid Genre_id { get; }
        public Guid Game_id { get; set; }
        public string Name { get; set; }

        public string Title { get; set; }
        public Genre Genre { get; }
        public Game Game { get; }


    }
}
