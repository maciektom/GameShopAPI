namespace InternetGameShopAPI.Domain
{

    public class Developer
    {

        public int DeveloperID { get; set; }
        public string Name { get; set; }
        public Developer(int developerID, string name)
        {
            DeveloperID = developerID;
            Name = name;
        }
    }
}

