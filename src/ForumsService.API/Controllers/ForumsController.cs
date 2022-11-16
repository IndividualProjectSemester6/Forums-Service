using ForumsService.API.Models;
using ForumsService.Application.Commands.CreateForum;
using ForumsService.Application.Commands.DeleteForum;
using ForumsService.Application.Commands.UpdateForum;
using ForumsService.Application.Queries.GetAllForums;
using ForumsService.Application.Queries.GetForum;
using ForumsService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ForumsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ForumViewModel>> GetAll()
        {
            var query = new GetAllForumsQuery();
            var result = await _mediator.Send(query);
            List<ForumViewModel> forums = new List<ForumViewModel>();
            foreach (var forum in result)
            {
                forums.Add(new ForumViewModel(forum.Id, forum.Name, forum.Description));
            }

            return Ok(forums);
        }

        [HttpGet("{forumId}")]
        public async Task<ActionResult> Get(Guid forumId)
        {
            var result = await _mediator.Send(new GetForumQuery(forumId));
            if (result != null)
            {
                var forum = new ForumViewModel(result.Id, result.Name, result.Description);
                return Ok(forum);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateForumViewModel forumViewModel)
        {
            var command = new CreateForumCommand(forumViewModel.Name, forumViewModel.Description);
            var result = await _mediator.Send(command);

            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(ForumViewModel forum)
        {
            var existingForum = new ForumDto(forum.Id, forum.Name, forum.Description);
            var command = new UpdateForumCommand(existingForum);
            var result = await _mediator.Send(command);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{forumId}")]
        public async Task<ActionResult> Delete(Guid forumId)
        {
            var result = await _mediator.Send(new DeleteForumCommand(forumId));
            if (result == null) return BadRequest();

            return Ok(result);
        }
    }
}
