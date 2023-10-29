using System.Xml.Linq;

namespace InternetGameShopAPI.Domain
{

    public class Genre
    {


        public Guid GenreID { get; set; }
        public string Name { get; set; }
        public Genre(Guid genreID, string name)
        {
            GenreID = genreID;
            Name = name;
        }
    }
}
