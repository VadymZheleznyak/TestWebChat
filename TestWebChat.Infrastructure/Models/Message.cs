namespace TestWebChat.Infrastructure.Models
{
    using System;
    public class Message
    {
        public Guid Id { get; set; }
        public string StringMessage { get; set; }
        public DateTime DateTime { get; set; }

        public Room Room { get; set; }
    }
}
