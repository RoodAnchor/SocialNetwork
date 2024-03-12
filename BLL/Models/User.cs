namespace SocialNetwork.BLL.Models
{
    public class User
    {
        public Int32 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Photo { get; set; }
        public String FavoriteMovie { get; set; }
        public String FavoriteBook { get; set; }
        public IEnumerable<Message> IncomingMessages { get; set; }
        public IEnumerable<Message> OutcomingMessages { get; set; }

        public User(
            Int32 id,
            String firstName,
            String lastName,
            String password,
            String email,
            String photo,
            String favoriteMovie,
            String favoriteBook,
            IEnumerable<Message> inbox,
            IEnumerable<Message> outbox) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
            Photo = photo;
            FavoriteMovie = favoriteMovie;
            FavoriteBook = favoriteBook;
            IncomingMessages = inbox;
            OutcomingMessages = outbox;
        }
    }
}
