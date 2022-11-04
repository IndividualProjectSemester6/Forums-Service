using ForumsService.API.Models;
using ForumsService.Application.Queries.GetAllForums;
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
                forums.Add(new ForumViewModel(forum.Id, forum.Name, forum.Description, forum.Rules));
            }

            return Ok(forums);
        }
    }
}
