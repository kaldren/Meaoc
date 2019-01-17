using System.Collections.Generic;
using System.Threading.Tasks;
using Meaoc_API.Domain.Dtos;
using Meaoc_API.Domain.Models;

namespace Meaoc_API.Services
{
    public interface IMessageService
    {
         Task<Message> CreateMessage(CreateMessageDto createMessageDto);
         Task<ViewMessageDto> GetMessageById(int id);
         Task<DeleteMessageDto> DeleteMessageById(int id, int recipientTokenId);
         Task<List<ViewMessageDto>> GetAllUserMessagesReceived(int recipientId);
    }
}