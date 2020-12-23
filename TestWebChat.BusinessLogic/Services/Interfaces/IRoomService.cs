namespace TestWebChat.BusinessLogic.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestWebChat.Infrastructure.Models;

    public interface IRoomService
    {
        IEnumerable<Room> GetAll();
        Task<Room> FindByIdAsync(Guid id);
        void Create(Room room);
        void Remove(Room item);
    }
}
