using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views.Friends
{
    public class AddFriendView
    {
        private FriendService _friendService;

        public AddFriendView(FriendService friendService) =>
            _friendService = friendService;

        public void Show(User user)
        {
            Console.Clear();
            Console.WriteLine("Добавить в друзья");
            Console.WriteLine();

            Console.WriteLine("Введите Email человека, которого хотите добавить в друзья:");
            String email = Console.ReadLine();

            Friend friend = new Friend(user.Id, email);

            try
            {
                _friendService.AddFriend(friend);
                SuccessMessage.Show($"Пользователь {email} добавлен в друзья");
            }
            catch(UserNotFoundException)
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
