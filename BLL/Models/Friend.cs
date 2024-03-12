namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public Friend(
            Int32 userId,
            String friendEmail)
        {
            UserId = userId;
            FriendEmail = friendEmail;
        }

        public Int32 Id { get; set; }
        public Int32 UserId { get; set; }
        public String FriendEmail { get; set; }
    }
}