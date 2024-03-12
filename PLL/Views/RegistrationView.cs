using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Screens
{
    public class RegistrationView
    {
        private UserService _userService;

        public RegistrationView(UserService userService) =>
            _userService = userService;

        public void Show()
        {
            Console.Clear();
            Console.WriteLine($"Регистрация пользователя{Environment.NewLine}");

            UserRegistrationData userRegistrationData = new UserRegistrationData();

            Console.WriteLine("Для регистрации пользователя введите");
            Console.Write("Имя: ");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.Write("Фамилия: ");
            userRegistrationData.LastName = Console.ReadLine();

            Console.Write("Пароль: ");
            userRegistrationData.Password = Console.ReadLine();

            Console.Write("Email: ");
            userRegistrationData.Email = Console.ReadLine();

            try
            {
                _userService.Register(userRegistrationData);

                SuccessMessage.Show("Регистрация прошла успешно");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла обшибка при регистрации");
            }
        }
    }
}
