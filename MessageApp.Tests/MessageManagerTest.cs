using MessageApp.Core;
using MessageApp.Infrastructure;
using MessageApp.Manager;
using Moq;

namespace MessageApp.Tests;

public class MessageManagerTest
{
    private readonly IMessageManager _messageManager;
    private readonly Mock<IMessageRepository> _messageRepositoryMock;
    public MessageManagerTest()
    {
        _messageRepositoryMock = new Mock<IMessageRepository>();
        _messageManager = new MessageManager(_messageRepositoryMock.Object);
        

    }

    [Fact]
    public async Task MessageManagerTest_AddMessage_Returns_It()
    {


        MessageModel messageModel = new()
        {
            MessageId = Guid.NewGuid(),
            MessageVersion = "1",
            MessageDada = "test data"
        };

        _messageRepositoryMock.Setup(p => p.AddMessage(It.IsAny<MessageModel>())).ReturnsAsync(messageModel);

        var result = await _messageManager.AddMessage(messageModel);
       Assert.NotNull(result);

        Assert.Equal(result.MessageId, messageModel.MessageId);
    }

    [Fact]
    public async Task MessageManagerTest_GetMessageByMessageId_Returns_It()
    {


        MessageModel messageModel = new()
        {
            MessageId = Guid.NewGuid(),
            MessageVersion = "1",
            MessageDada = "test data"
        };

        _messageRepositoryMock.Setup(p => p.GetMessageByMessageId(It.IsAny<string>())).ReturnsAsync(messageModel);

        var result = await _messageManager.GetMessageByMessageId(messageModel.MessageId.ToString());
        Assert.NotNull(result);

        Assert.Equal(result.MessageId, messageModel.MessageId);
    }
}