using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views
{
    public class UserOutcomingMessageView
    {
        public void Show(IEnumerable<Message> outcomingMessages) 
        {
            Console.Clear();
            Console.WriteLine($"Исходящие{Environment.NewLine}");

            if (outcomingMessages.Count() == 0)
                Console.WriteLine("Отправленных сообщений нет");

            foreach (Message message in outcomingMessages)
            {
                Console.WriteLine($"Кому: {message.SenderEmail}");
                Console.WriteLine($"Сообщение: {message.Content}{Environment.NewLine}");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("(нажмите ENTER, чтобы вернуться назад)");
            Console.ReadLine();
        }
    }
}
