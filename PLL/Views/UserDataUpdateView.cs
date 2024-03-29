﻿using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Screens
{
    public class UserDataUpdateView
    {
        private UserService _userService;

        public UserDataUpdateView(UserService userService) =>
            _userService = userService;

        public void Show(User user)
        {
            Console.Clear();
            Console.WriteLine($"Редактирование профиля{Environment.NewLine}");

            Console.Write("Меня зовут: ");
            user.FirstName = Console.ReadLine();

            Console.Write("Моя фамилия: ");
            user.LastName = Console.ReadLine();

            Console.Write("Ссылка на моё фото: ");
            user.Photo = Console.ReadLine();

            Console.Write("Мой любимый фильм: ");
            user.FavoriteMovie = Console.ReadLine();

            Console.Write("Моя любимая книга: ");
            user.FavoriteBook = Console.ReadLine();

            _userService.Update(user);

            SuccessMessage.Show("Ваш профиль успешно обновлён!");
        }
    }
}
