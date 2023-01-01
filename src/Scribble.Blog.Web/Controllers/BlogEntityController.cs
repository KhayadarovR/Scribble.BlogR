using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scribble.Blog.Web.Features.Commands;
using Scribble.Blog.Web.Features.Queries;
using Scribble.Blog.Web.Infrastructure.Attributes;
using Scribble.Blog.Web.Models;

namespace Scribble.Blog.Web.Controllers;

[ApiController]
[Route("api/blogs")]
public class BlogEntityController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public BlogEntityController(IMediator mediator) =>
        _mediator = mediator;

    [HttpGet("{id:guid}")]
    [FeatureGroupName("BlogEntity")]
    [ProducesResponseType(typeof(BlogEntityViewModel), StatusCodes.Status200OK)]
    public async Task<BlogEntityViewModel> GetBlogById(Guid id) =>
        await _mediator.Send(new GetBlogByIdQuery(id), HttpContext.RequestAborted)
            .ConfigureAwait(false);

    [HttpPost]
    [FeatureGroupName("BlogEntity")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<Guid> PostBlog(BlogEntityCreateViewModel model) =>
        await _mediator.Send(new PostBlogEntityCommand(model), HttpContext.RequestAborted)
            .ConfigureAwait(false);
}