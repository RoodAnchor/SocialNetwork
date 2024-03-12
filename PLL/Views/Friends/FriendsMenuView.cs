using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views.Friends
{
    public class FriendsMenuView
    {
        public void Show(User user, List<User> friends)
        {
            Console.WriteLine("Добавить друга (нажмите 1)");

            if (friends.Any())
                Console.WriteLine("Удалить друга (нажите 2)");

            Console.WriteLine("Вернуться в главное меню (нажмите 3)");

            String val = Console.ReadLine();

            if (val == "3")
                Program.userMenuView.Show(user);

            switch (val)
            {
                case "1":
                    FriendsView.addFriendView.Show(user);
                    break;

                case "2":
                    FriendsView.removeFriendView.Show(user);
                    break;
            }
        }
    }
}
