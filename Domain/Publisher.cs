namespace InternetGameShopAPI.Domain
{


    public class Publisher
    {
        public int PublisherID { get; set; }
        public string Name { get; set; }
        public Publisher(int publisherID, string name)
        {
            PublisherID = publisherID;
            Name = name;
        }
    }

}

