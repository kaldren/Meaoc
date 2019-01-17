using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meaoc_API.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        public int RecipientId { get; set; }
        public User Recipient { get; set; }

        public Message()
        {
            DateSent = DateTime.Now;
        }
    }
}