using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Screens
{
    public class MessageSendingView
    {
        private UserService _userService;
        private MessageService _messageService;

        public MessageSendingView( 
            MessageService messageService,
            UserService userService)
        {
            _userService = userService;
            _messageService = messageService;
        }

        public void Show(ref User user) 
        {
            Console.Clear();
            Console.WriteLine($"Отправка сообщения{Environment.NewLine}");

            MessageSendingData messageSendingData = new MessageSendingData();

            Console.Write("Email получателя: ");
            messageSendingData.RecipientEmail = Console.ReadLine();

            Console.Write("Сообщение (не более 5000 символов): ");
            messageSendingData.Content = Console.ReadLine();

            messageSendingData.SenderId = user.Id;

            try
            {
                _messageService.SendMessage(messageSendingData);

                SuccessMessage.Show("Сообщение успешно отправлено");

                user = _userService.FindById(user.Id);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение");
            }
            catch (Exception) 
            {
                AlertMessage.Show("Произошла ошибка при отправке сообщения");
            }
        }
    }
}
