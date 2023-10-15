﻿using Microsoft.EntityFrameworkCore;
using SimpleChat.BL.Entities;
using SimpleChat.Infrastructure.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Infrastructure.Data
{
    public class SimpleChatDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }
        public DbSet<Message> Messages { get; set; }

        public SimpleChatDbContext(DbContextOptions<SimpleChatDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChatUserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
