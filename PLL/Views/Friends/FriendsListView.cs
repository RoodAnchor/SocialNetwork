using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views.Friends
{
    public class FriendsListView
    {
        public void Show(List<User> friends)
        {
            if (friends.Any())
            {
                foreach (User friend in friends)
                {
                    Console.WriteLine($"{friend.FirstName} {friend.LastName} ({friend.Email})");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("У вас пока нет друзей");
                Console.WriteLine();
            }
        }
    }
}
