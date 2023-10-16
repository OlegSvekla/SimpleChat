using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleChat.Core.Entities;

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

                // Заполнение начальных данных для моделей Chat, User, ChatUser и Message

                if (!await dbContext.Users.AnyAsync())
                {
                    await dbContext.Users.AddRangeAsync(GetPreConfiguredUsers());
                    await dbContext.SaveChangesAsync();
                }

                if (!await dbContext.Chats.AnyAsync())
                {
                    await dbContext.Chats.AddRangeAsync(GetPreConfiguredChats());
                    await dbContext.SaveChangesAsync();
                }

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
                new Chat { ChatName = "Chat 1", UserCreatorId = 1 },
                new Chat { ChatName = "Chat 2", UserCreatorId = 2 },
                new Chat { ChatName = "Chat 3", UserCreatorId = 3 },
                new Chat { ChatName = "Chat 4", UserCreatorId = 4 },
                new Chat { ChatName = "Chat 5", UserCreatorId = 5 }
            };
        }

        private static IEnumerable<ChatUser> GetPreConfiguredChatUsers()
        {
            //var users = GetPreConfiguredUsers().ToList();
            //var chats = GetPreConfiguredChats().ToList(); // Получаем список созданных чатов

            // Здесь создаем связи между пользователями и чатами
            var chatUsers = new List<ChatUser>
            {
                new ChatUser { UserId = 1, ChatId = 1 },
                new ChatUser { UserId = 2, ChatId = 1 },
                new ChatUser { UserId = 3, ChatId = 1 },

                new ChatUser { UserId = 1, ChatId = 2 },
                new ChatUser { UserId = 2, ChatId = 2 },
                new ChatUser { UserId = 5, ChatId = 2 },

                new ChatUser { UserId = 3, ChatId = 3 },
                new ChatUser { UserId = 4, ChatId = 3 },
                new ChatUser { UserId = 5, ChatId = 3 },

                new ChatUser { UserId = 1, ChatId = 4 },
                new ChatUser { UserId = 5, ChatId = 4 },

                new ChatUser { UserId = 2, ChatId = 5 },
                new ChatUser { UserId = 4, ChatId = 5 }
            };

            return chatUsers;
        }

        private static IEnumerable<Message> GetPreConfiguredMessages()
        {
            //var users = GetPreConfiguredUsers().ToList();
            //var chats = GetPreConfiguredChats().ToList(); // Получаем список созданных чатов

            // Здесь создаем сообщения для чатов
            var messages = new List<Message>
            {       
                new Message { Content = "User 1 to Chat 1", UserId = 1, ChatId = 1 },
                new Message { Content = "User 2 to Chat 1", UserId = 2, ChatId = 1 },
                new Message { Content = "User 3 to Chat 1", UserId = 3, ChatId = 1 },

                new Message { Content = "User 1 to Chat 2", UserId = 1, ChatId = 2 },
                new Message { Content = "User 2 to Chat 2", UserId = 2, ChatId = 2 },
                new Message { Content = "User 5 to Chat 2", UserId = 5, ChatId = 2 },

                new Message { Content = "User 3 to Chat 3", UserId = 3, ChatId = 3 },
                new Message { Content = "User 4 to Chat 3", UserId = 4, ChatId = 3 },
                new Message { Content = "User 5 to Chat 3", UserId = 5, ChatId = 3 },

                new Message { Content = "User 1 to Chat 4", UserId = 1, ChatId = 4 },
                new Message { Content = "User 5 to Chat 4", UserId = 5, ChatId = 4 },

                new Message { Content = "User 2 to Chat 5", UserId = 2, ChatId = 5 },
                new Message { Content = "User 4 to Chat 5", UserId = 4, ChatId = 5 }
            };

            return messages;
        }
    }
}
