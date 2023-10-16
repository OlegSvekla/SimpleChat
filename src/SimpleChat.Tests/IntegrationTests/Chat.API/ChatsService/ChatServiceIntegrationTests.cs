using Xunit;
using Moq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SimpleChat.Core.Entities;
using SimpleChat.Core.Dtos;
using SimpleChat.Infrastructure.Data.Repositories;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using SimpleChat.Core.Interfaces.IRepositories;
using SimpleChat.Api.Interfaces.Implementation.Services;

namespace SimpleChat.Tests.IntegrationTests.Chats.API.ChatsService
{
    public class ChatServiceIntegrationTests
    {
        [Fact]
        public async Task GetById_WithValidChatId_ReturnsChatDto()
        {
            // Arrange
            var chatRepository = new Mock<IChatRepository>();
            var mapper = new Mock<IMapper>();

            var chatId = 1;
            var chatName = "SampleChat";
            var sampleChat = new Chat
            {
                Id = chatId,
                ChatName = chatName,
                UserCreatorId = 1,
                UserCreator = new User { Name = "User1" }
            };

            chatRepository.Setup(repo => repo.GetOneByAsync(
                It.IsAny<Func<IQueryable<Chat>, IIncludableQueryable<Chat, object>>>(),
                It.IsAny<Expression<Func<Chat, bool>>>(),
                CancellationToken.None
            ))
            .ReturnsAsync(sampleChat);

            mapper.Setup(m => m.Map<ChatDto>(It.IsAny<Chat>()))
                .Returns<Chat>(chat => new ChatDto 
                { Id = chat.Id, ChatName = chat.ChatName, 
                    UserCreator = new UserDto { Name = chat.UserCreator.Name } 
                });

            var chatService = new ChatService(chatRepository.Object, mapper.Object, null);

            // Act
            var result = await chatService.GetById(chatId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(chatId, result.Id);
            Assert.Equal(chatName, result.ChatName);
            Assert.NotNull(result.UserCreator);
            Assert.Equal("User1", result.UserCreator.Name);
        }

        [Fact]
        public async Task GetByChatName_WithValidChatName_ReturnsChatDto()
        {
            // Arrange
            var chatRepository = new Mock<IChatRepository>();
            var mapper = new Mock<IMapper>();
            var logger = new Mock<ILogger<ChatService>>();

            var chatName = "SampleChat";
            var sampleChat = new Chat
            {
                Id = 1,
                ChatName = chatName,
                UserCreatorId = 1,
                UserCreator = new User { Name = "User1" }
            };

            chatRepository.Setup(repo => repo.GetOneByAsync(
                It.IsAny<Func<IQueryable<Chat>, IIncludableQueryable<Chat, object>>>(),
                It.IsAny<Expression<Func<Chat, bool>>>(),
                CancellationToken.None
            ))
            .ReturnsAsync(sampleChat);

            mapper.Setup(m => m.Map<ChatDto>(It.IsAny<Chat>()))
                .Returns<Chat>(chat => new ChatDto
                { Id = chat.Id, ChatName = chat.ChatName,
                    UserCreator = new UserDto { Name = chat.UserCreator.Name } 
                });

            var chatService = new ChatService(chatRepository.Object, mapper.Object, logger.Object);

            // Act
            var result = await chatService.GetByChatName(chatName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(chatName, result.ChatName);
            Assert.NotNull(result.UserCreator);
            Assert.Equal("User1", result.UserCreator.Name);
        }

        [Fact]
        public async Task AddChat_WithValidChatDto_ReturnsTrue()
        {
            // Arrange
            var chatRepository = new Mock<IChatRepository>();
            var mapper = new Mock<IMapper>();
            var logger = new Mock<ILogger<ChatService>>();

            var chatDto = new ChatDto
            {
                ChatName = "NewChat"
            };

            chatRepository.Setup(repo => repo.GetOneByAsync(
                It.IsAny<Func<IQueryable<Chat>, IIncludableQueryable<Chat, object>>>(),
                It.IsAny<Expression<Func<Chat, bool>>>(),
                CancellationToken.None
            ))
            .ReturnsAsync((Chat)null);

            chatRepository.Setup(repo => repo.CreateAsync(It.IsAny<Chat>(), CancellationToken.None))
                .ReturnsAsync(new Chat());

            var chatService = new ChatService(chatRepository.Object, mapper.Object, logger.Object);

            // Act
            var result = await chatService.AddChat(chatDto);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteChat_WithValidChatIdAndCurrentUser_ReturnsChatDto()
        {
            // Arrange
            var chatRepository = new Mock<IChatRepository>();
            var mapper = new Mock<IMapper>();
            var logger = new Mock<ILogger<ChatService>>();

            var chatId = 1;
            var currentUserId = 1;

            var chatToDelete = new Chat
            {
                Id = chatId,
                UserCreatorId = currentUserId
            };

            chatRepository.Setup(repo => repo.GetOneByAsync(
                It.IsAny<Func<IQueryable<Chat>, IIncludableQueryable<Chat, object>>>(),
                It.IsAny<Expression<Func<Chat, bool>>>(),
                CancellationToken.None
            ))
            .ReturnsAsync(chatToDelete);

            chatRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Chat>(), CancellationToken.None))
                .Returns<Chat, CancellationToken>((chat, _) => Task.FromResult(chat));

            mapper.Setup(m => m.Map<ChatDto>(It.IsAny<Chat>()))
                .Returns<Chat>(chat => new ChatDto { Id = chat.Id, ChatName = chat.ChatName });

            var chatService = new ChatService(chatRepository.Object, mapper.Object, logger.Object);

            // Act
            var result = await chatService.DeleteChat(chatId, currentUserId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(chatId, result.Id);
        }

        [Fact]
        public async Task DeleteChat_WithValidChatIdAndNonCurrentUser_ReturnsNull()
        {
            // Arrange
            var chatRepository = new Mock<IChatRepository>();
            var mapper = new Mock<IMapper>();
            var logger = new Mock<ILogger<ChatService>>();

            var chatId = 1;
            var currentUserId = 2;

            var chatToDelete = new Chat
            {
                Id = chatId,
                UserCreatorId = 1
            };

            chatRepository.Setup(repo => repo.GetOneByAsync(
                It.IsAny<Func<IQueryable<Chat>, IIncludableQueryable<Chat, object>>>(),
                It.IsAny<Expression<Func<Chat, bool>>>(),
                CancellationToken.None
            ))
            .ReturnsAsync(chatToDelete);

            var chatService = new ChatService(chatRepository.Object, mapper.Object, logger.Object);

            // Act
            var result = await chatService.DeleteChat(chatId, currentUserId);

            // Assert
            Assert.Null(result);
        }
    }
}
