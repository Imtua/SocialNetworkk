namespace SocialNetworkBackground.DAL.Entities
{
    public class UserEntity
    {
        public int id { get; set; } 
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string photo { get; set; }
        public string favorite_movie { get; set; }
        public string favorite_book { get; set; }

    }
}
