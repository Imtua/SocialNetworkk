using SocialNetworkBackground.DAL.Entities;

namespace SocialNetworkBackground.DAL.Interfaces
{
    public interface IMessageRepository
    {
        int Create(MessageEntity messageEntity);
        IEnumerable<MessageEntity> FindBySenderId(int senderId);
        IEnumerable<MessageEntity> FindByRecipientId(int recipientId);
        int DeleteById(int messageId);
    }
}
