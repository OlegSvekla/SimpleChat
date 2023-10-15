using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SimpleChat.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Infrastructure.EntitiesConfiguration
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Content).IsRequired();

            builder.HasOne(m => m.User)
                   .WithMany(u => u.Messages)
                   .HasForeignKey(m => m.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Chat)
                   .WithMany(c => c.Messages)
                   .HasForeignKey(m => m.ChatId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
