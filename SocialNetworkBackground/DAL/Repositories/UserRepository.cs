using SocialNetworkBackground.DAL.Entities;
using SocialNetworkBackground.DAL.Interfaces;

namespace SocialNetworkBackground.DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public int Create(UserEntity userEntity)
        {
            return Execute(@"insert into user(first_name, last_name, password, email)
                                values(:first_name, :last_name, :password, :email)", userEntity);
        }

        public int DeleteById(int id)
        {
            return Execute(@"delete from user where id=:id_p", new { id_p = id });
        }

        public IEnumerable<UserEntity> FindAll()
        {
            return Query<UserEntity>(@"select * from user");
        }

        public UserEntity FindByEmail(string email)
        {
            return QueryFirstOrDefault<UserEntity>(@"select * from user where email = :email_p", new { email_p = email });
        }

        public UserEntity FindById(int id)
        {
            return QueryFirstOrDefault<UserEntity>(@"select * from user where id = id_p", new { id_p = id });
        }

        public int Update(UserEntity userEntity)
        {
            return Execute(@"update user set first_name = :first_name, last_name = :last_name, email = :email, password = :password
                                photo = :photo, favorite_movie = :favorite_movie, favorite_book = :favorite_book", userEntity);
        }
    }
}
