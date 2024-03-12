using Moq;
using Xunit;

using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Exceptions;

namespace SocialNetwork.Tests
{
    public class UserServicesTests
    {
        private UserService _userService = 
            new UserService(new UserRepository());

        private UserAuthenticationData _userAuthenticationData = 
            new UserAuthenticationData()
            {
                Email = "test@email.com",
                Password = "password"
            };

        private UserEntity _userEntity =
            new UserEntity()
            {
                password = "password"
            };

        #region Authenticate() tests
        [Fact]
        public void AuthenticateShouldNotReturnNull()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.FindByEmail("test@email.com")).Returns(_userEntity);

            UserService userService = new UserService(mock.Object);
            Assert.NotNull(userService.Authenticate(_userAuthenticationData));
        }

        [Fact]
        public void AuthenticateShouldThrowUserNotFoundException()
        {
            _userAuthenticationData.Email = "wee@test.com";

            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.FindByEmail("test@email.com")).Returns(_userEntity);

            UserService userService = new UserService(mock.Object);
            Assert.Throws<UserNotFoundException>(() => userService.Authenticate(_userAuthenticationData));
        }

        [Fact]
        public void AuthenticateShouldThrowWrongPasswordException()
        {
            _userAuthenticationData.Password = "FooBar";

            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.FindByEmail("test@email.com")).Returns(_userEntity);

            UserService userService = new UserService(mock.Object);
            Assert.Throws<WrongPasswordException>(() => userService.Authenticate(_userAuthenticationData));
        }
        #endregion Authenticate() tests

        #region FindByEmail() tests
        [Fact]
        public void FindByEmailShouldNotReturnNull()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.FindByEmail("test@email.com")).Returns(_userEntity);

            UserService userService = new UserService(mock.Object);
            Assert.NotNull(userService.FindByEmail("test@email.com"));
        }

        [Fact]
        public void FindByEmailShouldThrowUserNotFoundException() =>
            Assert.Throws<UserNotFoundException>(() => _userService.FindByEmail("test@email.com"));
        #endregion FindByEmail() tests

        #region FindById() tests
        [Fact]
        public void FindByIdShouldThrowUserNotFoundException() =>
            Assert.Throws<UserNotFoundException>(() => _userService.FindById(-1));

        [Fact]
        public void FindByIdShouldNotReturnNull()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.FindById(0)).Returns(_userEntity);

            UserService userService = new UserService(mock.Object);
            Assert.NotNull(userService.FindById(0));
        }
        #endregion FindById() tests
    }
}