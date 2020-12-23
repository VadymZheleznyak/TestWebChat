namespace TestWebChat.BusinessLogic.Services.Interfaces
{
    using System.Collections.Generic;
    using TestWebChat.BusinessLogic.Models;
    using TestWebChat.Infrastructure.Models;

    public interface IMessageService
    {
        IEnumerable<Message> GetAllMessagesFromRoom(string roomName);
        void Create(CreateMessageModel model);
    }
}
