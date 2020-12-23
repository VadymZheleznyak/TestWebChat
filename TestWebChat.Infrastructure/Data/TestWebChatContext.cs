namespace TestWebChat.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using TestWebChat.Infrastructure.Models;

    public class TestWebChatContext : DbContext
    {
        public TestWebChatContext()
        {
        }

        public TestWebChatContext(DbContextOptions<TestWebChatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlConnectionFactory.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Room>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.Room);
        }
    }
}
