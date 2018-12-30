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

        public IActionResult Create([FromBody] CreateMessageDto createMessageDto)
        {
            var message = _messageRepository.Create(createMessageDto);

            return Ok(createMessageDto);
        }
    }
}