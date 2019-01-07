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

        [HttpPost("create")]
        public IActionResult CreateMessage([FromBody] CreateMessageDto createMessageDto)
        {
            var message = _messageRepository.CreateMessage(createMessageDto);

            return Ok(createMessageDto);
        }

        // GET api/messages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            // TODO: Refactor this so it complies with SRP
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

        [HttpGet]
        public async Task<IActionResult> GetAllUserMessagesReceived()
        {
            // TODO: Refactor this so it complies with SRP
            int recipientTokenId;
            var isValidTokenId = Int32.TryParse(User.Identity.Name, out recipientTokenId);

            if (!isValidTokenId)
            {
                return Unauthorized(
                    new BaseApiResponse(HttpStatusCode.Unauthorized, "Unauthorized request",
                        new Dictionary<string, string> {
                            {"Unauthorized", $"Unauhtorized request"},
                        }));
            }

            var messages = await _messageRepository.GetAllUserMessagesReceived(recipientTokenId);

            return Ok(messages);
        }
    
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteMessageById(int id) 
        {
            try {
                // TODO: Refactor this so it complies with SRP
                int recipientTokenId;
                var isValidTokenId = Int32.TryParse(User.Identity.Name, out recipientTokenId);
                var messageToDelete = await _messageRepository.DeleteMessageById(id, recipientTokenId);

                
                if (messageToDelete == null) 
                {
                    return BadRequest("Invalid id");
                }

                return Ok(messageToDelete);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(
                    new BaseApiResponse(HttpStatusCode.Unauthorized, "Unauthorized",
                        new Dictionary<string, string> {
                            {"Unauthorized", $"Unauthorized request"},
                    }));
            }

        }
    }
}