namespace TestWebChat.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class TestWebChatIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public TestWebChatIdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
