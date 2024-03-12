using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

using SocialNetwork.BLL.Utilities;

namespace SocialNetwork.BLL.Services
{
    /// <summary>
    /// Класс предоставляющий доступ к методам работы с данными пользователя
    /// </summary>
    public class UserService
    {
        #region Fields
        private IUserRepository _userRepository;
        private MessageService _messageService;
        #endregion Fields

        #region Constructors
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _messageService = new MessageService();
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Метод регистрирует пользователя
        /// </summary>
        /// <param name="userRegistrationData">Данные о пользователе</param>
        /// <exception cref="Exception">Возникает при ошибке записи в БД</exception>
        public void Register(UserRegistrationData userRegistrationData)
        {
            RegistrationDataValidator registrationDataValidator =
                new RegistrationDataValidator(userRegistrationData, _userRepository);

            if (!registrationDataValidator.DataIsValid)
                throw registrationDataValidator.Exception;

            UserEntity userEntity = new UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                email = userRegistrationData.Email,
                password = userRegistrationData.Password
            };

            if (_userRepository.Create(userEntity) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Метод авторизует пользователя
        /// </summary>
        /// <param name="userAuthenticationData">Авторизационные данные пользователя</param>
        /// <returns>Объект <see cref="User"/></returns>
        /// <exception cref="UserNotFoundException">Возникает если не найден пользователь</exception>
        /// <exception cref="WrongPasswordException">Возникает если пароль неверный</exception>
        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            UserEntity userEntity = _userRepository.FindByEmail(userAuthenticationData.Email);

            if (userEntity is null)
                throw new UserNotFoundException();

            if (userEntity.password != userAuthenticationData.Password)
                throw new WrongPasswordException();

            return ConstructUserModel(userEntity);
        }

        /// <summary>
        /// Метод находит пользователя по Email
        /// </summary>
        /// <param name="email">Email пользователя</param>
        /// <returns>Объект <see cref="User"/></returns>
        /// <exception cref="UserNotFoundException">Возникает если пользователь не найден</exception>
        public User FindByEmail(String email)
        {
            UserEntity userEntity = _userRepository.FindByEmail(email);

            if (userEntity is null)
                throw new UserNotFoundException();

            return ConstructUserModel(userEntity);
        }

        /// <summary>
        /// Метод находит пользователя по ИД
        /// </summary>
        /// <param name="userId">ИД пользователя</param>
        /// <returns>Объект <see cref="User"/></returns>
        /// <exception cref="UserNotFoundException">Возникает если пользователь не найден</exception>
        public User FindById(Int32 userId)
        {
            UserEntity userEntity = _userRepository.FindById(userId);

            if (userEntity is null)
                throw new UserNotFoundException();

            return ConstructUserModel(userEntity);
        }

        /// <summary>
        /// Метод вносит изменения в данные пользователя
        /// </summary>
        /// <param name="user">Объект <see cref="User"/> который изменяется</param>
        /// <exception cref="Exception">Возникает если ошибка при записи в БД</exception>
        public void Update(User user)
        {
            UserEntity userEntity = new UserEntity()
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                password = user.Password,
                email = user.Email,
                photo = user.Photo,
                favorite_movie = user.FavoriteMovie,
                favorite_book = user.FavoriteBook
            };

            if (_userRepository.Update(userEntity) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Метод создаёт объект <see cref="User"/> из <see cref="UserEntity"/>
        /// </summary>
        /// <param name="userEntity">сущность БД</param>
        /// <returns>Объект <see cref="User"/></returns>
        private User ConstructUserModel(UserEntity userEntity)
        {
            return new User(
                userEntity.id,
                userEntity.firstname,
                userEntity.lastname,
                userEntity.password,
                userEntity.email,
                userEntity.photo,
                userEntity.favorite_movie,
                userEntity.favorite_book,
                _messageService.GetIncomingMessagesById(userEntity.id),
                _messageService.GetOutcomingMessagesByUserId(userEntity.id));
        }
        #endregion Methods
    }
}