using System.ComponentModel.DataAnnotations.Schema;

namespace ForumsService.Domain.Entities
{
    public class ForumDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ThreadDto> Threads { get; set; }

        public ForumDto(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public ForumDto()
        {
        }
    }
}