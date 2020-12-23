namespace TestWebChat.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using TestWebChat.Infrastructure.Data;
    using TestWebChat.Infrastructure.Models;
    using TestWebChat.Infrastructure.Repositories.Interfaces;

    public class MessagesRepository : IMessagesRepository
    {
        private DbSet<Message> _messageEntity;
        private TestWebChatContext _context;

        public MessagesRepository(TestWebChatContext context)
        {
            _messageEntity = context.Set<Message>();
            _context = context;
        }

        public void Create(Message item)
        {
            _messageEntity.Add(item);
            _context.SaveChanges();
        }

        public IEnumerable<Message> GetAll()
        {
            return _messageEntity.Include(r => r.Room).AsEnumerable();
        }
    }
}
