using System.Threading.Tasks;
using Meaoc_API.Data.Dtos;
using Meaoc_API.Data.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Meaoc_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpPost]
        public IActionResult CreateMessage([FromBody] CreateMessageDto createMessageDto)
        {
            var message = _messageRepository.CreateMessage(createMessageDto);

            return Ok(createMessageDto);
        }

        // GET api/messages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var message = await _messageRepository.GetMessageById(id);

            return Ok(message);
        }
    }
}