
using SocialNetworkBackground.DAL.Entities;
using SocialNetworkBackground.DAL.Interfaces;

namespace SocialNetworkBackground.DAL.Repositories
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public int Create(MessageEntity messageEntity)
        {
            return Execute(@"insert into message(content, sender_id, recipient_id) 
                values(:content, :sender_id, :recipient_id)", messageEntity);
        }

        public int DeleteById(int messageId)
        {
           return Execute(@"delete from message where id= :message_id", new { message_id = messageId });
        }

        public IEnumerable<MessageEntity> FindByRecipientId(int recipientId)
        {
            return Query<MessageEntity>(@"select * from message where recipient_id = :recipient_id_p",
                new { recipient_id_p = recipientId });
        }

        public IEnumerable<MessageEntity> FindBySenderId(int senderId)
        {
            return Query<MessageEntity>(@"select * from message where sender_id=:sender_id_p",
                new { sender_id_p =senderId });
        }
    }
}
