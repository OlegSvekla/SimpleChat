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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired();

            builder.HasMany(u => u.ChatUsers)
                   .WithOne(cu => cu.User)
                   .HasForeignKey(cu => cu.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Messages)
                   .WithOne(m => m.User)
                   .HasForeignKey(m => m.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.CreatedChats)
                   .WithOne(c => c.UserCreator)
                   .HasForeignKey(c => c.UserCreatorId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
