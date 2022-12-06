namespace ForumsService.API.Models
{
    public class ForumViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ThreadReferenceViewModel> Threads { get; set; }

        public ForumViewModel(Guid id, string name, string description, List<ThreadReferenceViewModel> threads)
        {
            Id = id;
            Name = name;
            Description = description;
            Threads = threads;
        }

        public ForumViewModel()
        {
        }
    }
}
