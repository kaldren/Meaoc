using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meaoc_API.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public User Author { get; set; }

        public int RecipientId { get; set; }
        [ForeignKey("RecipientId")]
        public User Recipient { get; set; }
    }
}