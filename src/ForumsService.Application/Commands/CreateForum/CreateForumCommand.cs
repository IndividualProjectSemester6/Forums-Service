using System.Text.Json.Serialization;
using ForumsService.Domain.Entities;
using MediatR;

namespace ForumsService.Application.Commands.CreateForum
{
    public class CreateForumCommand : IRequest<ForumDto>
    {
        public string Name { get; }
        public string Description { get; }

        [JsonConstructor]
        public CreateForumCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
