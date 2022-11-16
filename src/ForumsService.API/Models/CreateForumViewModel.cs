namespace ForumsService.API.Models
{
    public class CreateForumViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateForumViewModel(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public CreateForumViewModel()
        {
        }
    }
}
