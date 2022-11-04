using ForumsService.Domain.Entities;

namespace ForumsService.API.Models
{
    public class ForumViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ForumViewModel(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public ForumViewModel()
        {
        }
    }
}
