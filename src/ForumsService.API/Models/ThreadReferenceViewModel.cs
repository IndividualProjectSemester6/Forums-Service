namespace ForumsService.API.Models
{
    public class ThreadReferenceViewModel
    {
        public Guid ThreadId { get; set; }
        public ThreadReferenceViewModel(Guid threadId)
        {
            ThreadId = threadId;
        }
    }
}
