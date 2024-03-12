using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views
{
    public class UserMenuView
    {
        public void Show(User user) 
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine($"Входящие сообщения: {user.IncomingMessages.Count()}");
                Console.WriteLine($"Исходящие сообщения: {user.OutcomingMessages.Count()}");
                Console.WriteLine();

                Console.WriteLine("Посмотреть информацию о профиле (Нажмите 1)");
                Console.WriteLine("Редактировать мой профиль (Нажмите 2)");
                Console.WriteLine("Друзья (Нажмите 3)");
                Console.WriteLine("Написать сообщение (Нажмите 4)");
                Console.WriteLine("Посмотреть входящие сообщения (Нажмите 5)");
                Console.WriteLine("Посмотреть исходящие сообщения (Нажмите 6)");
                Console.WriteLine("Выйти из профиля (Нажмите 7)");

                String keyVal = Console.ReadLine();

                if (keyVal == "7")
                    Program.mainView.Show();

                switch (keyVal)
                {
                    case "1":
                        Program.userInfoView.Show(user);
                        break;

                    case "2":
                        Program.userDataUpdateView.Show(user);
                        break;

                    case "3":
                        Program.friendsView.Show(user);
                        break;

                    case "4":
                        Program.messageSendingView.Show(ref user);
                        break;

                    case "5":
                        Program.userIncomingMessageView.Show(user.IncomingMessages);
                        break;

                    case "6":
                        Program.userOutcomingMessageView.Show(user.OutcomingMessages);
                        break;
                }
            }
        }
    }
}
