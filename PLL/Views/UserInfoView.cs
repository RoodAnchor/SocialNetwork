using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Screens
{
    public class UserInfoView
    {
        public void Show(User user)
        {
            Console.Clear();
            Console.WriteLine($"Информация о профиле{Environment.NewLine}");

            Console.WriteLine("Информация о моём профиле");
            Console.WriteLine($"Мой ID:\t\t\t{user.Id}");
            Console.WriteLine($"Меня зовут:\t\t{user.FirstName}");
            Console.WriteLine($"Моя фамилия:\t\t{user.LastName}");
            Console.WriteLine($"Мой пароль:\t\t{user.Password}");
            Console.WriteLine($"Мой Email:\t\t{user.Email}");
            Console.WriteLine($"Ссылка на моё фото:\t{user.Photo}");
            Console.WriteLine($"Мой любимый фильм:\t{user.FavoriteMovie}");
            Console.WriteLine($"Моя любимая книга:\t{user.FavoriteBook}");

            Console.WriteLine();
            Console.WriteLine("(нажмите ENTER, чтобы вернуться назад)");
            Console.ReadLine();
        }
    }
}
