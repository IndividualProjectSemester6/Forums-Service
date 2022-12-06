using System.ComponentModel.DataAnnotations.Schema;

namespace ForumsService.Domain.Entities
{
    public class ThreadDto
    {
        public Guid Id { get; set; }
        [ForeignKey("Forum")]
        public Guid ForumId { get; set; }
        public ForumDto Forum { get; set; }
    }
}
