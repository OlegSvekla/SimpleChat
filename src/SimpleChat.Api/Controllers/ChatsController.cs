using FluentValidation;
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
        private readonly IValidator<ChatDto> _validator;

        public ChatsController(IChatService<ChatDto> chatService, IValidator<ChatDto> validator)
        {
            _chatService = chatService;
            _validator = validator;
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


        /// <summary>
        /// Add book
        /// </summary>   
        /// <param name="bookDto">The Book to be created.</param>
        /// <returns>Ok response succesefully created book in DATA.</returns>
        /// <response code="201">Book is created.</response>
        [ProducesResponseType(201, Type = typeof(ChatDto))]
        [HttpPost]
        public async Task<IActionResult> AddChat([FromBody] ChatDto chatDto)
        {
            var validationResult = await _validator.ValidateAsync(chatDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToString());

            }
            var success = await _chatService.AddChat(chatDto);

            return success == false ? BadRequest("Your Email is not unique") : Ok();
        }

        /// <summary>
        /// Removes book with the specified ID.
        /// </summary>        
        /// <param name="id">The ID of the Book to be removed.</param>
        /// <response code="204">The book was successfully removed.</response>
        /// <response code="404">The book with this Id was not found.</response>
        [HttpDelete("{chatId:int}")]
        [ProducesResponseType(204, Type = typeof(ChatDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteBook(int chatId, int currentUserId)
        {
            var success = await _chatService.DeleteChat( chatId,  currentUserId);

            return success == null ? NotFound() : NoContent();
        }
    }
}

