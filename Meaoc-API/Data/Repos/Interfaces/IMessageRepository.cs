using System.Threading.Tasks;
using Meaoc_API.Data.Dtos;
using Meaoc_API.Data.Models;

namespace Meaoc_API.Data.Repos.Interfaces
{
    public interface IMessageRepository
    {
         Task<Message> CreateMessage(CreateMessageDto createMessageDto);
         Task<ViewMessageDto> GetMessageById(int id);
    }
}