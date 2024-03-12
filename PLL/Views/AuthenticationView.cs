using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Screens
{
    public class AuthenticationView
    {
        private UserService _userService;
        public AuthenticationView(UserService userService) =>
            _userService = userService;

        public void Show()
        {
            Console.Clear();
            Console.WriteLine($"Авторизация{Environment.NewLine}");

            UserAuthenticationData userAuthenticationData = new UserAuthenticationData();

            Console.Write("Email: ");
            userAuthenticationData.Email = Console.ReadLine();

            Console.Write("Пароль: ");
            userAuthenticationData.Password = Console.ReadLine();

            try
            {
                Console.Clear();
                User user = _userService.Authenticate(userAuthenticationData);

                SuccessMessage.Show($"Вы успешно авторизовались!{Environment.NewLine}" +
                    $"Здравствуйте, {user.FirstName}{Environment.NewLine}");

                Program.userMenuView.Show(user);
            }
            catch (WrongPasswordException)
            {
                AlertMessage.Show($"Пароль некорректный!{Environment.NewLine}");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show($"Пользователь не найден!{Environment.NewLine}");
            }
        }
    }
}
