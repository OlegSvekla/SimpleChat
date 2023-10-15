using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SimpleChat.BL.Entities;

namespace SimpleChat.Infrastructure.EntitiesConfiguration
{
    public class ChatUserConfiguration : IEntityTypeConfiguration<ChatUser>
    {
        public void Configure(EntityTypeBuilder<ChatUser> builder)
        {
            builder.HasKey(cu => new { cu.UserId, cu.ChatId });

            builder.HasOne(cu => cu.User)
                   .WithMany(u => u.ChatUsers)
                   .HasForeignKey(cu => cu.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cu => cu.Chat)
                   .WithMany(c => c.ChatUsers)
                   .HasForeignKey(cu => cu.ChatId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
