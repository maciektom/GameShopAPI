namespace InternetGameShopAPI.Domain.UserAggregate
{
    public class UserReview
    {
        public Guid ReviewID { get; set; }
        public Guid GameID { get; set; }
        public Guid UserID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime DatePosted { get; set; }

        public UserReview(Guid reviewID, Guid gameID, Guid userID, int rating, string comment, DateTime datePosted)
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