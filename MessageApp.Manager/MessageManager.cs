using MessageApp.Core;
using MessageApp.Infrastructure;

namespace MessageApp.Manager;

public class MessageManager : IMessageManager
{
    private readonly IMessageRepository _messageRepository;
    public MessageManager(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<MessageModel> AddMessage(MessageModel messageModel)
    {
        return await _messageRepository.AddMessage(messageModel);
    }

    public async Task<MessageModel> GetMessageByMessageId(string messageId)
    {
        return await _messageRepository.GetMessageByMessageId(messageId);
    }
}