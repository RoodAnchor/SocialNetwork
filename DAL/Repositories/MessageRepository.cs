using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public Int32 Create(MessageEntity messageEntity) =>
            Execute(@"insert into messages (content, sender_id, recipient_id)
                    values (:content, :sender_id, :recipient_id)", messageEntity);

        public IEnumerable<MessageEntity> FindBySenderId(Int32 senderId) =>
        Query<MessageEntity>("select * from messages where sender_id = :sender_id",
                new { sender_id = senderId });

        public IEnumerable<MessageEntity> FindByRecipientId(Int32 recipientId) =>
            Query<MessageEntity>("select * from messages where recipient_id = :recipient_id",
                new { recipient_id = recipientId });

        public Int32 DeleteById(Int32 messageId) =>
            Execute("delete from message where id = :id_p", new { id_p = messageId });
    }
}