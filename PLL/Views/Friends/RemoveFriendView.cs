using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views.Friends
{
    public class RemoveFriendView
    {
        private FriendService _friendService;

        public RemoveFriendView(FriendService friendService) =>
            _friendService = friendService;

        public void Show(User user)
        {
            Console.Clear();
            Console.WriteLine("Удалить из друзей");
            Console.WriteLine();

            Console.WriteLine("Введите Email человека, которого хотите удалить из друзей:");
            String email = Console.ReadLine();

            try
            {
                _friendService.RemoveFriend(user, email);

                SuccessMessage.Show($"Пользователь {email} удалён из друзей");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка");
            }
        }
    }
}
