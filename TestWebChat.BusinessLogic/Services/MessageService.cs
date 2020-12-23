namespace TestWebChat.BusinessLogic.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TestWebChat.BusinessLogic.Models;
    using TestWebChat.BusinessLogic.Services.Interfaces;
    using TestWebChat.Infrastructure.Models;
    using TestWebChat.Infrastructure.Repositories.Interfaces;

    public class MessageService : IMessageService
    {
        protected IMessagesRepository _repository;
        protected IRoomRepository _roomRepository;

        public MessageService(IMessagesRepository repository, IRoomRepository roomRepository)
        {
            _repository = repository;
            _roomRepository = roomRepository;
        }

        public void Create(CreateMessageModel model)
        {
            var room = _roomRepository.GetAll().SingleOrDefault(x => x.RoomName == model.RoomName);
            var message = new Message
            {
                StringMessage = model.Message,
                DateTime = DateTime.Now,
                Room = room
            };
            _repository.Create(message);
        }

        public IEnumerable<Message> GetAllMessagesFromRoom(string roomName)
        {
            return _repository.GetAll().AsEnumerable()
                .Where(x => x.Room.RoomName == roomName)
                .OrderBy(x => x.DateTime)
                .ToList();
        }
    }
}
