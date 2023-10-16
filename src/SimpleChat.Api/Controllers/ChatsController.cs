using FluentValidation;
using Microsoft.AspNetCore.Mvc;
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

        public ChatsController(
            IChatService<ChatDto> chatService,
            IValidator<ChatDto> validator)
        {
            _chatService = chatService;
            _validator = validator;
        }

        /// <param name="id">ID of the Chat to get.</param>
        /// <returns>Ok response containing a single chat.</returns>
        /// <response code="200">Returns one chat.</response>
        /// <response code="404">The chat with this Id was not found.</response>
        [ProducesResponseType(200, Type = typeof(ChatDto))]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatDto>> GetChatById([FromRoute] int id)
        {
            var chat = await _chatService.GetById(id);

            return chat == null ? NotFound("User not found woth this Id") : Ok(chat);
        }

        /// <param name="chatName">Name of the Chat to get.</param>
        /// <returns>Ok response containing a single chat.</returns>
        /// <response code="200">Returns one chat.</response>
        /// <response code="404">The chat with this ChatName was not found.</response>
        [ProducesResponseType(200, Type = typeof(ChatDto))]
        [ProducesResponseType(404)]
        [HttpGet("name/{chatName}")]
        public async Task<ActionResult<ChatDto>> GetChatByChatName(string chatName)
        {
            var chat = await _chatService.GetByChatName(chatName);

            return chat == null ? NotFound("User not found woth this Name") : Ok(chat);
        }
 
        /// <param name="chatDto">The Chat to be created.</param>
        /// <returns>Ok response succesefully created chat in DATA.</returns>
        /// <response code="201">Chat is created.</response>
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

            return success == false ? BadRequest("This chat is already existing") : Ok();
        }

        /// <param name="chatId">The ID of the chat to be removed.</param>
        /// <param name="creatorId">The ID of the chat creator to be removed.</param> 
        /// <response code="204">The chat was successfully removed.</response>
        /// <response code="404">The chat with this Id was not found.</response>
        [HttpDelete("{chatId:int}/{creatorId:int}")]
        [ProducesResponseType(204, Type = typeof(ChatDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteChat(
            [FromRoute] int chatId,
            [FromRoute] int creatorId)
        {
            var success = await _chatService.DeleteChat(chatId, creatorId);

            return success == null ? NotFound() : NoContent();
        }
    }
}

