using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scribble.Blog.Models;
using Scribble.Blog.Web.Definitions.Documentation;
using Scribble.Blog.Web.Features.Commands;
using Scribble.Blog.Web.Features.Queries;
using Scribble.Blog.Web.Models;

namespace Scribble.Blog.Web.Controllers;

[ApiController]
[Route("api/blogs")]
public class BlogEntityController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IBlogEntityRepository _repository;

    public BlogEntityController(IMediator mediator, IBlogEntityRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    [HttpGet("{id:guid}")]
    [FeatureGroupName("BlogEntity")]
    [ProducesResponseType(typeof(BlogEntityViewModel), StatusCodes.Status200OK)]
    public async Task<BlogEntityViewModel> GetBlogById(Guid id) =>
        await _mediator.Send(new GetBlogByIdQuery(id), HttpContext.RequestAborted)
            .ConfigureAwait(false);

    [HttpGet]
    [FeatureGroupName("BlogEntity")]
    [ProducesResponseType(typeof(BlogEntityViewModel), StatusCodes.Status200OK)]
    public List<BlogEntity> GetBlogs()
    {
        return _repository.GetBlogs();
    }
    

    [HttpPost]
    [FeatureGroupName("BlogEntity")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<Guid> PostBlog(BlogEntityCreateViewModel model) =>
        await _mediator.Send(new PostBlogEntityCommand(model), HttpContext.RequestAborted)
            .ConfigureAwait(false);

    [HttpPut]
    [FeatureGroupName("BlogEntity")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task PutBlog(BlogEntityUpdateViewModel model) =>
        await _mediator.Send(new PutBlogEntityCommand(model), HttpContext.RequestAborted)
            .ConfigureAwait(false);

    [HttpDelete("{id:guid}")]
    [FeatureGroupName("BlogEntity")]
    [ProducesResponseType(typeof(BlogEntityViewModel), StatusCodes.Status200OK)]
    public async Task<BlogEntityViewModel> DeleteBlog(Guid id) =>
        await _mediator.Send(new DeleteBlogEntityCommand(id), HttpContext.RequestAborted)
            .ConfigureAwait(false);
}