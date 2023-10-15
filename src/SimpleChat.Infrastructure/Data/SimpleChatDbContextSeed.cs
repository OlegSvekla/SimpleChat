using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleChat.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Infrastructure.Data
{
    public class SimpleChatDbContextSeed
    {
        public static async Task SeedAsyncData(SimpleChatDbContext dbContext, ILogger logger, int retry = 0)
        {
            var retryForAvailability = retry;

            try
            {
                logger.LogInformation("Data seeding started.");

                //// Заполнение начальных данных для моделей Chat, User, ChatUser и Message
                //if (!await dbContext.Chats.AnyAsync())
                //{
                //    await dbContext.Chats.AddRangeAsync(GetPreConfiguredChats());
                //    await dbContext.SaveChangesAsync();
                //}

                //if (!await dbContext.Users.AnyAsync())
                //{
                //    await dbContext.Users.AddRangeAsync(GetPreConfiguredUsers());
                //    await dbContext.SaveChangesAsync();
                //}

                if (!await dbContext.ChatUsers.AnyAsync())
                {
                    await dbContext.ChatUsers.AddRangeAsync(GetPreConfiguredChatUsers());
                    await dbContext.SaveChangesAsync();
                }

                if (!await dbContext.Messages.AnyAsync())
                {
                    await dbContext.Messages.AddRangeAsync(GetPreConfiguredMessages());
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;
                {
                    retryForAvailability++;

                    logger.LogError(ex.Message);
                    await SeedAsyncData(dbContext, logger, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<User> GetPreConfiguredUsers()
        {
            return new List<User>
            {
                new User { Name = "User 1" },
                new User { Name = "User 2" },
                new User { Name = "User 3" },
                new User { Name = "User 4" },
                new User { Name = "User 5" }
            };
        }

        private static IEnumerable<Chat> GetPreConfiguredChats()
        {
            return new List<Chat>
            {
                new Chat { ChatName = "Chat 1", CreatorUserId = 1 },
                new Chat { ChatName = "Chat 2", CreatorUserId = 2 },
                new Chat { ChatName = "Chat 3", CreatorUserId = 3 },
                new Chat { ChatName = "Chat 4", CreatorUserId = 4 },
                new Chat { ChatName = "Chat 5", CreatorUserId = 5 },
            };
        }

        private static IEnumerable<ChatUser> GetPreConfiguredChatUsers()
        {
            var users = GetPreConfiguredUsers().ToList();
            var chats = GetPreConfiguredChats().ToList(); // Получаем список созданных чатов

            // Здесь создаем связи между пользователями и чатами
            var chatUsers = new List<ChatUser>
            {
                new ChatUser { UserId = users[0].Id, ChatId = chats[0].Id },
                new ChatUser { UserId = users[1].Id, ChatId = chats[0].Id },
                new ChatUser { UserId = users[2].Id, ChatId = chats[0].Id },

                new ChatUser { UserId = users[0].Id, ChatId = chats[1].Id },
                new ChatUser { UserId = users[1].Id, ChatId = chats[1].Id },
                new ChatUser { UserId = users[4].Id, ChatId = chats[1].Id },

                new ChatUser { UserId = users[2].Id, ChatId = chats[2].Id },
                new ChatUser { UserId = users[3].Id, ChatId = chats[2].Id },
                new ChatUser { UserId = users[4].Id, ChatId = chats[2].Id },

                new ChatUser { UserId = users[0].Id, ChatId = chats[3].Id },
                new ChatUser { UserId = users[4].Id, ChatId = chats[3].Id },

                new ChatUser { UserId = users[1].Id, ChatId = chats[4].Id },
                new ChatUser { UserId = users[3].Id, ChatId = chats[4].Id },
            };

            return chatUsers;
        }

        private static IEnumerable<Message> GetPreConfiguredMessages()
        {
            var users = GetPreConfiguredUsers().ToList();
            var chats = GetPreConfiguredChats().ToList(); // Получаем список созданных чатов

            // Здесь создаем сообщения для чатов
            var messages = new List<Message>
            {       
                new Message { Content = "User 1 to Chat 1", UserId = users[0].Id, ChatId = chats[0].Id },
                new Message { Content = "User 2 to Chat 1", UserId = users[1].Id, ChatId = chats[0].Id },
                new Message { Content = "User 3 to Chat 1", UserId = users[2].Id, ChatId = chats[0].Id },

                new Message { Content = "User 1 to Chat 2", UserId = users[0].Id, ChatId = chats[1].Id },
                new Message { Content = "User 2 to Chat 2", UserId = users[1].Id, ChatId = chats[1].Id },
                new Message { Content = "User 5 to Chat 2", UserId = users[4].Id, ChatId = chats[1].Id },

                new Message { Content = "User 3 to Chat 3", UserId = users[2].Id, ChatId = chats[2].Id },
                new Message { Content = "User 4 to Chat 3", UserId = users[3].Id, ChatId = chats[2].Id },
                new Message { Content = "User 5 to Chat 3", UserId = users[4].Id, ChatId = chats[2].Id },

                new Message { Content = "User 1 to Chat 4", UserId = users[0].Id, ChatId = chats[3].Id },
                new Message { Content = "User 5 to Chat 4", UserId = users[4].Id, ChatId = chats[3].Id },

                new Message { Content = "User 2 to Chat 5", UserId = users[1].Id, ChatId = chats[4].Id },
                new Message { Content = "User 4 to Chat 5", UserId = users[3].Id, ChatId = chats[4].Id },
            };

            return messages;
        }
    }
}
