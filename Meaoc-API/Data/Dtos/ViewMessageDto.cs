using System;

namespace Meaoc_API.Data.Dtos
{
    public class ViewMessageDto
    {
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        public int AuthorId { get; set; }
        public int RecipientId { get; set; }
    }
}