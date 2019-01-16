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
        private readonly IMessageService _messageRepository;

        public MessagesController(IMessageService messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpPost("create")]
        public IActionResult CreateMessage([FromBody] CreateMessageDto createMessageDto)
        {
            // TODO: Refactor this so it complies with SRP
            int userTokenId;
            var isValidTokenId = Int32.TryParse(User.Identity.Name, out userTokenId);

            createMessageDto.AuthorId = userTokenId;

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

            if (GetTokenId() == -1)
            {
                return Unauthorized(
                    new BaseApiResponse(HttpStatusCode.Unauthorized, "Unauthorized request"));
            }

            var message = await _messageRepository.GetMessageById(id);

            // Only the author and the recipient are authorized to read the message
            if (message.AuthorId != userTokenId && message.RecipientId != userTokenId)
            {
                return Unauthorized(
                    new BaseApiResponse(HttpStatusCode.Unauthorized, "Unauthorized request"));
            }

            return Ok(message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserMessagesReceived()
        {
            // TODO: Refactor this so it complies with SRP
            int recipientTokenId;
            var isValidTokenId = Int32.TryParse(User.Identity.Name, out recipientTokenId);

            if (GetTokenId() == -1)
            {
                return Unauthorized(
                    new BaseApiResponse(HttpStatusCode.Unauthorized, "Unauthorized request"));
            }

            var messages = await _messageRepository.GetAllUserMessagesReceived(recipientTokenId);

            return Ok(messages);
        }
    
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteMessageById(int id) 
        {
            try {
                var messageToDelete = await _messageRepository
                                                .DeleteMessageById(id, GetTokenId());

                
                if (messageToDelete == null) 
                {
                    return BadRequest("Invalid id");
                }

                return Ok(messageToDelete);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(
                    new BaseApiResponse(HttpStatusCode.Unauthorized, "Unauthorized request"));
            }

        }

        public int GetTokenId()
        {
            int recipientTokenId;
            var isValidTokenId = Int32.TryParse(User.Identity.Name, out recipientTokenId);

            return isValidTokenId ? recipientTokenId : -1;
        }
    }
}