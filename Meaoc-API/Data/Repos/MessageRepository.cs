using System;
using System.Collections.Generic;
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

        public async Task<ViewMessageDto> GetMessageById(int messageId)
        {
            var message = await _context.Messages.Include(p => p.Author)
                                    .Where(p => p.Id == messageId).SingleOrDefaultAsync();

            var messageToReturn = _mapper.Map<ViewMessageDto>(message);

            return messageToReturn;
        }

        public async Task<Message> CreateMessage(CreateMessageDto createMessageDto, string recipientUsername)
        {
            var recipientId = _context.Users.FirstOrDefaultAsync(p => p.Username == recipientUsername);
            createMessageDto.RecipientId = recipientId.Id;

            var message = BuildMessage(createMessageDto);

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return message;
        }

        private Message BuildMessage(CreateMessageDto createMessageDto)
        {
            var message = _mapper.Map<Message>(createMessageDto);

            return message;
        }

        private async Task<bool> IsMessageAuthorOrRecipient(int messageId) 
        {
            var message = await _context.Messages.FirstOrDefaultAsync(p => p.Id  == messageId);

            return false;
        }

        public async Task<List<ViewMessageDto>> GetAllUserMessagesReceived(int recipientId)
        {
            var messages = await _context.Messages.Include(p => p.Author)
                                    .Where(p => p.RecipientId == recipientId).ToListAsync();

            var messagesToReturn = _mapper.Map<List<ViewMessageDto>>(messages);

            return messagesToReturn;
        }
    }
}