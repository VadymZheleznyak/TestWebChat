namespace TestWebChat.Infrastructure.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestWebChat.Infrastructure.Models;

    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
        Task<Room> FindByIdAsync(Guid id);
        void Create(Room item);
        void Remove(Room item);
    }
}
