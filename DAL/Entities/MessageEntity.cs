namespace SocialNetwork.DAL.Entities
{
    public class MessageEntity
    {
        public Int32 id { get; set; }
        public String content { get; set; }
        public Int32 sender_id { get; set; }
        public Int32 recipient_id { get; set; }
    }
}
