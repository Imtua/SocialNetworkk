using SocialNetworkBackground.DAL.Entities;

namespace SocialNetworkBackground.DAL.Interfaces
{
    public interface IFriendRepository
    {
        int Create(FriendEntity friendEntity);
        IEnumerable<FriendEntity> FindAllByUserId(int userId);
        int Delete(int id);
    }
}
