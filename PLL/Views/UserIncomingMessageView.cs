using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views
{
    public class UserIncomingMessageView
    {
        public void Show(IEnumerable<Message> incomingMessages) 
        {
            Console.Clear();
            Console.WriteLine($"Входящие{Environment.NewLine}");

            if (incomingMessages.Count() == 0)
                Console.WriteLine("Входящих сообщений нет");

            foreach(Message message in incomingMessages)
            {
                Console.WriteLine($"От: {message.SenderEmail}");
                Console.WriteLine($"Сообщение: {message.Content}{Environment.NewLine}");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("(нажмите ENTER, чтобы вернуться назад)");
            Console.ReadLine();
        }
    }
}
