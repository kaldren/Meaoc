using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Meaoc_API.Data.Dtos;
using Meaoc_API.Data.Models;
using Meaoc_API.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Meaoc_API.Data.Repos
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MeaocContext _context;
        private readonly IMapper _mapper;

        public MessageRepository(MeaocContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ViewMessageDto> GetMessageById(int id)
        {
            var message = await _context.Messages.FirstOrDefaultAsync(p => p.Id  == id);

            var messageToReturn = _mapper.Map<ViewMessageDto>(message);

            return messageToReturn;
        }

        public async Task<Message> CreateMessage(CreateMessageDto createMessageDto)
        {
            var message = BuildMessage(createMessageDto);

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return message;
        }

        private Message BuildMessage(CreateMessageDto createMessageDto)
        {
            var message = _mapper.Map<Message>(createMessageDto);
            message.AuthorId = 1;

            return message;
        }
    }
}