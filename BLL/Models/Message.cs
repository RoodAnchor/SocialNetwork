namespace SocialNetwork.BLL.Models
{
    public class Message
    {
        public Message(
            Int32 id, 
            String content, 
            String senderEmail, 
            String recipientEmail)
        {
            Id = id;
            Content = content;
            SenderEmail = senderEmail;
            RecipientEmail = recipientEmail;
        }

        public Int32 Id { get; set; }
        public String Content { get; set; }
        public String SenderEmail { get; set; }
        public String RecipientEmail { get; set; }
    }
}
