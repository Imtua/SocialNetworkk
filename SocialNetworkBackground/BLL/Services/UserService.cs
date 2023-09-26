using SocialNetworkBackground.BLL.Models;
using SocialNetworkBackground.DAL.Entities;
using SocialNetworkBackground.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialNetworkBackground.BLL.Services
{
    public class UserService
    {
        private UserRepository _userRepository;
        public UserService()
        {
            _userRepository = new();
        }

        public void Register(UserRegistrationData userRegistrationData)
        {
            #region Проверка входных параметрова

            if (string.IsNullOrEmpty(userRegistrationData.FirstName))
                throw new ArgumentNullException("Имя не может быть пустым полем.", nameof(userRegistrationData.FirstName));

            if (string.IsNullOrEmpty(userRegistrationData.LastName))
                throw new ArgumentNullException("Фамилия не может быть пустым полем.", nameof(userRegistrationData.LastName));

            if (string.IsNullOrEmpty(userRegistrationData.Password))
                throw new ArgumentNullException("Пароль не может быть пустым полем.", nameof(userRegistrationData.Password));

            if (string.IsNullOrEmpty(userRegistrationData.Email))
                throw new ArgumentNullException("Email не может быть пустым полем.", nameof(userRegistrationData.Email));

            if(userRegistrationData.Password.Length < 8)
                throw new ArgumentException("Длина пароля должна быть больше 8 символов.", nameof(userRegistrationData.Password));

            if(!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
                throw new ArgumentException("Некорректный формат для Email.", nameof(userRegistrationData.Email));

            if (_userRepository.FindByEmail(userRegistrationData.Email) != null)
                throw new ArgumentException("Пользователь с таким Email уже существует.", nameof(userRegistrationData.Email));

            #endregion

            var user = new UserEntity()
            {
                first_name = userRegistrationData.FirstName,
                last_name = userRegistrationData.LastName,
                email = userRegistrationData.Email,
                password = userRegistrationData.Password,
            };

            if(_userRepository.Create(user) == 0)
                throw new Exception();
        }
    }
}
