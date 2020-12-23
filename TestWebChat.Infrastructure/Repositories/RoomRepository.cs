namespace TestWebChat.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TestWebChat.Infrastructure.Data;
    using TestWebChat.Infrastructure.Models;
    using TestWebChat.Infrastructure.Repositories.Interfaces;

    public class RoomRepository : IRoomRepository
    {
        private DbSet<Room> _roomEntity;
        private TestWebChatContext _context;

        public RoomRepository(TestWebChatContext context)
        {
            _roomEntity = context.Set<Room>();
            _context = context;
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomEntity.AsEnumerable();
        }

        public Task<Room> FindByIdAsync(Guid id)
        {
            return _roomEntity.SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Create(Room item)
        {
            _roomEntity.Add(item);
            _context.SaveChanges();
        }

        public void Remove(Room item)
        {
            _roomEntity.Remove(item);
            _context.SaveChanges();
        }
    }
}
