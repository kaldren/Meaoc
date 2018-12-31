using System;
using Meaoc_API.Data.Models;

namespace Meaoc_API.Data.Dtos
{
    public class ViewMessageDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }

        public int AuthorId { get; set; }
        public string AuthorUsername { get; set; }

        public int RecipientId { get; set; }
        public string RecipientUsername { get; set; }
    }
}