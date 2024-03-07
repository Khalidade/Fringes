using Fringes.Dtos;
using Fringes.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fringes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessages()
        {
            var messages = await _messageService.GetMessagesAsync();
            return Ok(messages);
        }

        [HttpPost]
        public async Task<ActionResult<MessageDto>> CreateMessages(CreateMessageDto createMessageDto)
        {


            var createdMessage = await _messageService.CreateMessageAsync(createMessageDto);
            return CreatedAtAction(nameof(GetMessages), new { id = createdMessage.Id }, createdMessage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage(int id, UpdateMessageDto updateMessageDto)
        {
            try
            {
                await _messageService.UpdateMessageAsync(id, updateMessageDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            try
            {
                await _messageService.DeleteMessageAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
