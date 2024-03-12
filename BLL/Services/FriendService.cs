using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Exceptions;

namespace SocialNetwork.BLL.Services
{
    /// <summary>
    /// Класс предоставляющий доступ к метода работы с данными друзей
    /// </summary>
    public class FriendService
    {
        #region Fields
        private IFriendRepository _friendRepository;
        private IUserRepository _userRepository;
        #endregion Fields

        #region Constructors
        public FriendService()
        {
            _friendRepository = new FriendRepository();
            _userRepository = new UserRepository();
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Метод добавляет пользователя в друзья
        /// </summary>
        /// <param name="friend">Объект с данными о пользователе</param>
        /// <exception cref="UserNotFoundException">Исключение выбрасывается 
        /// если искомый пользователь не найден </exception>
        /// <exception cref="Exception">Исключение вызывается 
        /// если произошла ошибка при записи в БД</exception>
        public void AddFriend(Friend friend)
        {
            UserEntity userEntity = _userRepository.FindByEmail(friend.FriendEmail);

            if (userEntity is null)
                throw new UserNotFoundException();

            FriendEntity friendEntity = new FriendEntity()
            {
                id = friend.Id,
                user_id = friend.UserId,
                friend_id = userEntity.id,
            };

            if (_friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Метод удаляет пользователя из друзей
        /// </summary>
        /// <param name="user">Пользователь у которого неоходимо удалить</param>
        /// <param name="email">Email пользователя которого неоходимо удалить</param>
        /// <exception cref="UserNotFoundException">Исключение выбрасывается 
        /// если искомый пользователь не найден </exception>
        /// <exception cref="Exception">Исключение вызывается 
        /// если произошла ошибка при записи в БД</exception>
        public void RemoveFriend(User user, String email)
        {
            Friend friend = GetFriends(user).FirstOrDefault(x => x.FriendEmail == email);

            if (friend is null)
                throw new UserNotFoundException();

            if (_friendRepository.Delete(friend.Id) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Метод получает список друзей пользователя
        /// </summary>
        /// <param name="user">Пользователь друзей 
        /// которго необходимо получить</param>
        /// <returns>Перечесление объектов <see cref="Friend"/></returns>
        public IEnumerable<Friend> GetFriends(User user) =>
            _friendRepository
                .FindAllByUserId(user.Id)
                .Select(x =>
                    new Friend(
                        x.user_id,
                        _userRepository.FindById(x.friend_id).email)
                    { Id = x.id });
        #endregion Methods
    }
}
