using SocialNetworkBackground.DAL.Entities;
using SocialNetworkBackground.DAL.Interfaces;

namespace SocialNetworkBackground.DAL.Repositories
{
    public class FriendRepository : BaseRepository, IFriendRepository
    {
        public int Create(FriendEntity friendEntity)
        {
            return Execute(@"insert into friend(user_id, friend_id) values
                (:user_id, :friend_id)", friendEntity);
        }

        public int Delete(int id)
        {
            return Execute(@"delete from friend where id = :id_p", new { id_p = id });
        }

        public IEnumerable<FriendEntity> FindAllByUserId(int userId)
        {
            return Query<FriendEntity>(@"select * from friend where user_id = :user_id_p",
                new { user_id_p = userId });
        }
    }
}
