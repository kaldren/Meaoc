using AutoMapper;
using Meaoc_API.Data.Dtos;
using Meaoc_API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meaoc_API.Meaoc_API.Test.BusinessLogic
{
    public class MessageService
    {
        private readonly MeaocContext _context;
        private readonly IMapper _mapper;

        public MessageService(MeaocContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ViewMessageDto> GetAllUserMessagesReceived(int recipientId)
        {
            var messages = _context.Messages
                                    .Include(p => p.Author)
                                    .Where(p => p.RecipientId == recipientId)
                                    .OrderByDescending(p => p.DateSent)
                                    .GroupBy(p => p.AuthorId)
                                    .Select(grp => grp.First())
                                    .OrderByDescending(p => p.DateSent)
                                    .ToListAsync();

            var messagesToReturn = _mapper.Map<List<ViewMessageDto>>(messages);

            return messagesToReturn;
        }
    }
}
