using Microsoft.EntityFrameworkCore;
using SimpleChat.Core.Entities;
using SimpleChat.Infrastructure.EntitiesConfiguration;

namespace SimpleChat.Infrastructure.Data
{
    public class SimpleChatDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }

        public SimpleChatDbContext(DbContextOptions<SimpleChatDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.ApplyConfiguration(new ChatUserConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
