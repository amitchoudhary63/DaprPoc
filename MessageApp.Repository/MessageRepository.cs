using Dapr.Client;
using MessageApp.Core;
using MessageApp.Core.Constants;

namespace MessageApp.Infrastructure;

public class MessageRepository : IMessageRepository
{
    public MessageRepository()
    {
        
    }

    public async Task<MessageModel> AddMessage(MessageModel messageModel)
    {
        messageModel.MessageId = Guid.NewGuid();
        using var client = new DaprClientBuilder().Build();
         await client.SaveStateAsync(StoreConstants.DAPR_STORE_NAME, messageModel.MessageId.ToString(), messageModel);
        return messageModel;
    }

    public async Task<MessageModel> GetMessageByMessageId(string messageId)
    {
        using var client = new DaprClientBuilder().Build();
        MessageModel result = await client.GetStateAsync<MessageModel>(StoreConstants.DAPR_STORE_NAME, messageId);
        return result;
    }
}
