using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SimpleChat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Infrastructure.EntitiesConfiguration
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ChatName).IsRequired();

            builder.HasMany(c => c.ChatUsers)
                   .WithOne(cu => cu.Chat)
                   .HasForeignKey(cu => cu.ChatId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Messages)
                   .WithOne(m => m.Chat)
                   .HasForeignKey(m => m.ChatId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.UserCreator)
                   .WithMany(u => u.CreatedChats)
                   .HasForeignKey(c => c.UserCreatorId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
