using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleChat.BL.Entities;
using SimpleChat.Core.Dtos;
using SimpleChat.Core.Interfaces.IServices;

namespace SimpleChat.Api.Controllers
{
    [ApiController]
    [Route("api/chats")]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService<ChatDto> _chatService;

        public ChatsController(IChatService<ChatDto> chatService)
        {
            _chatService = chatService;
        }

        /// <summary>
        /// Gets the book by its own Id
        /// </summary>   
        /// <param name="id">ID of the Book to get.</param>
        /// <returns>Ok response containing a single book.</returns>
        /// <remarks>
        /// We have five books and five Id identification key. Enter any number from 1 to 5 inclusive.
        /// </remarks>
        /// <response code="200">Returns one book.</response>
        /// <response code="404">The book with this Id was not found.</response>
        [ProducesResponseType(200, Type = typeof(ChatDto))]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatDto>> GetChatById(int id)
        {
            var chat = await _chatService.GetChatById(id);

            return chat == null ? NotFound("User not found woth this Id") : Ok(chat);
        }


        [ProducesResponseType(200, Type = typeof(ChatDto))]
        [ProducesResponseType(404)]
        [HttpGet("chatName/{chatName}")]
        public async Task<ActionResult<ChatDto>> GetChatByChatName(string chatName)
        {
            var chat = await _chatService.GetChatByChatName(chatName);

            return chat == null ? NotFound("User not found woth this Id") : Ok(chat);
        }



    }
}

