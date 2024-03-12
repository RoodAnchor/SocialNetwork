using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services
{
    /// <summary>
    /// Класс предоставляющий доступ к методам работы с сообщениями.
    /// </summary>
    public class MessageService
    {
        #region Fields
        private IMessageRepository _messageRepository;
        private IUserRepository _userRepository;
        #endregion Fields

        #region Constructors
        public MessageService()
        {
            _messageRepository = new MessageRepository();
            _userRepository = new UserRepository();
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Метод получает входящие сообщения пользователя по ИД получателя.
        /// </summary>
        /// <param name="recipientId">ИД получателя</param>
        /// <returns>Коллекцию сообщений</returns>
        public IEnumerable<Message> GetIncomingMessagesById(Int32 recipientId)
        {
            List<Message> messages = new List<Message>();

            _messageRepository.FindByRecipientId(recipientId).ToList().ForEach(x =>
            {
                UserEntity senderUserEntity = _userRepository.FindById(x.sender_id);
                UserEntity recipientUserEntity = _userRepository.FindById(x.recipient_id);

                messages.Add(
                    new Message(
                        x.id,
                        x.content,
                        senderUserEntity.email,
                        recipientUserEntity.email));
            });

            return messages;
        }

        /// <summary>
        /// Метод получает список отправленных сообщений пользователя по ИД отпавителя
        /// </summary>
        /// <param name="senderId">ИД отправителя</param>
        /// <returns>Коллекцию отправленных сообщений</returns>
        public IEnumerable<Message> GetOutcomingMessagesByUserId(Int32 senderId)
        {
            List<Message> messages = new List<Message>();

            var msgs = _messageRepository.FindBySenderId(senderId);

            _messageRepository.FindBySenderId(senderId).ToList().ForEach(x =>
            {
                UserEntity senderUserEntity = _userRepository.FindById(x.sender_id);
                UserEntity recipientUserEntity = _userRepository.FindById(x.recipient_id);

                messages.Add(
                    new Message(
                        x.id,
                        x.content,
                        senderUserEntity.email,
                        recipientUserEntity.email));
            });

            return messages;
        }

        /// <summary>
        /// Метод отсылает сообщение пользователю.
        /// </summary>
        /// <param name="messageSendingData">Данные о сообщении.</param>
        /// <exception cref="ArgumentNullException">Вызывается если тело 
        /// сообщения пустое.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Вызывается если тело 
        /// сообщения длинной более 5000 символов</exception>
        /// <exception cref="UserNotFoundException">Вызывается если адресат не найден</exception>
        /// <exception cref="Exception">Вызывается если произошла ошибка при записи в БД</exception>
        public void SendMessage(MessageSendingData messageSendingData)
        {
            if (String.IsNullOrEmpty(messageSendingData.Content))
                throw new ArgumentNullException();

            if (messageSendingData.Content.Length > 5000)
                throw new ArgumentOutOfRangeException();

            UserEntity userEntity = _userRepository.FindByEmail(messageSendingData.RecipientEmail);
            if (userEntity is null) throw new UserNotFoundException();

            MessageEntity messageEntity = new MessageEntity()
            {
                content = messageSendingData.Content,
                sender_id = messageSendingData.SenderId,
                recipient_id = userEntity.id
            };

            if (_messageRepository.Create(messageEntity) == 0)
                throw new Exception();
        }
        #endregion Methods
    }
}
