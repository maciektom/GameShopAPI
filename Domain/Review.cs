namespace InternetGameShopAPI.Domain
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int GameID { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime DatePosted { get; set; }

        public Review(int reviewID, int gameID, int userID, int rating, string comment, DateTime datePosted)
        {
            ReviewID = reviewID;
            GameID = gameID;
            UserID = userID;
            Rating = rating;
            Comment = comment;
            DatePosted = datePosted;
        }
    }
}
