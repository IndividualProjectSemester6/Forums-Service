namespace ForumsService.Domain.Entities
{
    public class ForumDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Rules { get; set; }

        public ForumDto(Guid id, string name, string description, string[] rules)
        {
            Id = id;
            Name = name;
            Description = description;
            Rules = rules;
        }
    }
}