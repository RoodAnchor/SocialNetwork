using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories
{
    public interface IMessageRepository
    {
        public Int32 Create(MessageEntity messageEntity);
        public IEnumerable<MessageEntity> FindBySenderId(Int32 senderId);
        public IEnumerable<MessageEntity> FindByRecipientId(Int32 recipientId);
        public Int32 DeleteById(Int32 id);
    }
}
