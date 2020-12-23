namespace TestWebChat.BusinessLogic.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestWebChat.BusinessLogic.Services.Interfaces;
    using TestWebChat.Infrastructure.Models;
    using TestWebChat.Infrastructure.Repositories.Interfaces;

    public class RoomService : IRoomService
    {
        protected IRoomRepository _repository;

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }

        public void Create(Room room)
        {
            _repository.Create(room);
        }

        public async Task<Room> FindByIdAsync(Guid id)
        {
            var result = await _repository.FindByIdAsync(id);
            return result;
        }

        public IEnumerable<Room> GetAll()
        {
            return _repository.GetAll();
        }

        public void Remove(Room item)
        {
            _repository.Remove(item);
        }
    }
}
