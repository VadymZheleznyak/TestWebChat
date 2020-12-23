namespace TestWebChat.Infrastructure.Repositories.Interfaces
{
    using System.Collections.Generic;
    using TestWebChat.Infrastructure.Models;

    public interface IMessagesRepository
    {
        IEnumerable<Message> GetAll();
        void Create(Message item);
    }
}
