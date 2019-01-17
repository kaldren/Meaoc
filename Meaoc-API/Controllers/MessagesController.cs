using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Meaoc_API.Domain.Dtos;
using Meaoc_API.Domain.Models;
using Meaoc_API.Services;
using Meaoc_API.Helpers.ApiResponses;
using Meaoc_API.Services.Messages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Int32;

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
            var tokenId = GetTokenId();

            if (tokenId == -1)
            {
                return Unauthorized(
                    new BaseApiResponse(HttpStatusCode.Unauthorized, "Unauthorized request"));
            }

            var message = new Message
            {
                AuthorId = tokenId,
                Content = createMessageDto.Content,
                RecipientId = createMessageDto.RecipientId
            };

            _messageRepository.CreateMessage(message);

            return Ok(createMessageDto);
        }

        // GET api/messages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var tokenId = GetTokenId();

            if (tokenId == -1)
            {
                return Unauthorized(
                    new BaseApiResponse(HttpStatusCode.Unauthorized, "Unauthorized request"));
            }

            var message = await _messageRepository.GetMessageById(id);

            // Only the author and the recipient are authorized to read the message
            if (message.AuthorId != tokenId && message.RecipientId != tokenId)
            {
                return Unauthorized(
                    new BaseApiResponse(HttpStatusCode.Unauthorized, "Unauthorized request"));
            }

            return Ok(message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserMessagesReceived()
        {
            var tokenId = GetTokenId();

            if (tokenId == -1)
            {
                return Unauthorized(
                    new BaseApiResponse(HttpStatusCode.Unauthorized, "Unauthorized request"));
            }

            var messages = await _messageRepository.GetAllUserMessagesReceived(tokenId);

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
            var isValidTokenId = TryParse(User.Identity.Name, out var recipientTokenId);

            return isValidTokenId ? recipientTokenId : -1;
        }
    }
}