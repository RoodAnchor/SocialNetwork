using System.ComponentModel.DataAnnotations;

using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Utilities
{
    internal class RegistrationDataValidator
    {
        internal Boolean DataIsValid { get; set; } = false;
        internal Exception Exception { get; set; }

        internal RegistrationDataValidator(
            UserRegistrationData userRegistrationData,
            IUserRepository userRepository) =>
            ValidateData(userRegistrationData, userRepository);

        private void ValidateData(
            UserRegistrationData userRegistrationData,
            IUserRepository userRepository)
        {
            if (String.IsNullOrEmpty(userRegistrationData.FirstName))
            {
                Exception = new ArgumentNullException();
                return;
            }

            if (String.IsNullOrEmpty(userRegistrationData.LastName))
            {
                Exception = new ArgumentNullException();
                return;
            }

            if (String.IsNullOrEmpty(userRegistrationData.Password))
            {
                Exception = new ArgumentNullException();
                return;
            }

            if (String.IsNullOrEmpty(userRegistrationData.Email))
            {
                Exception = new ArgumentNullException();
                return;
            }

            if (userRegistrationData.Password.Length < 8)
            {
                Exception = new ArgumentNullException();
                return;
            }

            if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
            {
                Exception = new ArgumentNullException();
                return;
            }

            if (userRepository.FindByEmail(userRegistrationData.Email) != null)
            {
                Exception = new ArgumentNullException();
                return;
            }

            DataIsValid = true;
        }
    }
}
