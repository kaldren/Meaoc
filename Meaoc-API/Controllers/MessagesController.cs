using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Meaoc_API.Data.Dtos;
using Meaoc_API.Data.Repos.Interfaces;
using Meaoc_API.Helpers.ApiResponses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meaoc_API.Controllers
{
    [Authorize]
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
            int userTokenId;
            var isValidTokenId = Int32.TryParse(User.Identity.Name, out userTokenId);

            if (!isValidTokenId)
            {
                return Unauthorized(
                    new BaseApiResponse(HttpStatusCode.Unauthorized, "Unauthorized request",
                        new Dictionary<string, string> {
                            {"Unauthorized", $"Unauhtorized request"},
                        }));
            }

            var message = await _messageRepository.GetMessageById(id);

            // Only the author and the recipient are authorized to read the message
            if (message.AuthorId != userTokenId && message.RecipientId != userTokenId)
            {
                return Unauthorized(
                    new BaseApiResponse(HttpStatusCode.Unauthorized, "Unauthorized request",
                        new Dictionary<string, string> {
                            {"Unauthorized", $"Unauthorized request"},
                        }));
            }

            return Ok(message);
        }


    }
}