using System;
using Meaoc_API.Domain.Models;

namespace Meaoc_API.Domain.Dtos
{
    public class ViewMessageDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }

        public bool IsRead { get; set; }

        public int AuthorId { get; set; }
        public string AuthorUsername { get; set; }

        public int RecipientId { get; set; }
        public string RecipientUsername { get; set; }
    }
}