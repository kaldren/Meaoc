using System.Collections.Generic;
using System.Threading.Tasks;
using Meaoc_API.Data.Dtos;
using Meaoc_API.Data.Models;

namespace Meaoc_API.Data.Repos.Interfaces
{
    public interface IMessageRepository
    {
         Task<Message> CreateMessage(CreateMessageDto createMessageDto, string recipientUsername);
         Task<ViewMessageDto> GetMessageById(int id);
         Task<List<ViewMessageDto>> GetAllUserMessagesReceived(int recipientId);
    }
}