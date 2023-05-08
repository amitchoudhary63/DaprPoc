using MessageApp.Core;

namespace MessageApp.Infrastructure;

public interface IMessageRepository
{
    Task<MessageModel> GetMessageByMessageId(string messageId);
    Task<MessageModel> AddMessage(MessageModel messageModel);
}
