namespace SocialNetwork.DAL.Entities
{
    public class UserEntity
    {
        public Int32 id { get; set; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String password { get; set; }
        public String email { get; set; }
        public String photo { get; set; }
        public String favorite_movie { get; set; }
        public String favorite_book { get; set; }
    }
}