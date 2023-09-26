using SocialNetworkBackground.DAL.Entities;
using SocialNetworkBackground.DAL.Repositories;

namespace SocialNetworkBackgroundTests.DALTests
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private UserRepository _userRepository = new UserRepository();

        [Test]
        public void CreateMustAddUser()
        {

            var userEntity = new UserEntity()
            {
                first_name = "Иван",
                last_name = "Иванов",
                email = "ivanov_i@gmail.com",
                password = "qwert12345"
            };

            Assert.That(_userRepository.Create(userEntity) != 0);
        }
    }
}
