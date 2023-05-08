using MessageApp.Core;

namespace MessageApp.Manager;

public interface IMessageManager
{
    Task<MessageModel> GetMessageByMessageId(string messageId);
    Task<MessageModel> AddMessage(MessageModel messageModel);
}
