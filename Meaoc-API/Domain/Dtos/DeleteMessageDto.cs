namespace Meaoc_API.Domain.Dtos
{
    public class DeleteMessageDto
    {
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int RecipientId { get; set; }
    }
}