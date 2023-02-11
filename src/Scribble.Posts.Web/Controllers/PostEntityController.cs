using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scribble.Posts.Web.Definitions.Identity;
using Scribble.Posts.Web.Features.Commands;
using Scribble.Posts.Web.Features.Queries;
using Scribble.Posts.Web.Models;

namespace Scribble.Posts.Web.Controllers;

[ApiController]
[Route("api/v1/posts")]
[Produces("application/json")]
[Authorize(AuthenticationSchemes = AuthenticationData.AuthenticationSchemes)]
public class PostEntityController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostEntityController(IMediator mediator) =>
        _mediator = mediator;

    [AllowAnonymous]
    [HttpGet("{postId:guid}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<PostEntityCreateViewModel> GetSinglePostById(Guid postId)
        => await _mediator.Send(new GetPostByIdQuery(postId), HttpContext.RequestAborted)
            .ConfigureAwait(false);

    [AllowAnonymous]
    [HttpGet("{userId:guid}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IEnumerable<PostEntityViewModel>> GetAllUserPostsById(Guid userId)
        => await _mediator.Send(new GetAllUserPostsByIdQuery(userId), HttpContext.RequestAborted)
            .ConfigureAwait(false);

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<Guid> CreatePost(PostEntityCreateViewModel model)
        => await _mediator.Send(new CreatePostCommand(model), HttpContext.RequestAborted)
            .ConfigureAwait(false);

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task UpdatePost(PostEntityUpdateViewModel model)
        => await _mediator.Send(new UpdatePostCommand(model), HttpContext.RequestAborted)
            .ConfigureAwait(false);

    [HttpDelete("{postId:guid}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task DeletePost(Guid postId)
        => await _mediator.Send(new DeletePostCommand(postId), HttpContext.RequestAborted)
            .ConfigureAwait(false);
}