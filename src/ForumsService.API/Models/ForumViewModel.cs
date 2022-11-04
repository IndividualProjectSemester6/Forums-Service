namespace ForumsService.API.Models
{
    public class ForumViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Rules { get; set; }

        public ForumViewModel(Guid id, string name, string description, string[] rules)
        {
            Id = id;
            Name = name;
            Description = description;
            Rules = rules;
        }

        public ForumViewModel()
        {
        }
    }
}
