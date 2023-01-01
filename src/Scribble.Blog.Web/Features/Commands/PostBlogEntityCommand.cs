using AutoMapper;
using MediatR;
using Scribble.Blog.Infrastructure.Contexts;
using Scribble.Blog.Models;
using Scribble.Blog.Web.Models;

namespace Scribble.Blog.Web.Features.Commands;

public class PostBlogEntityCommand : IRequest<Guid>
{
    public PostBlogEntityCommand(BlogEntityCreateViewModel model) =>
        Model = model;
    public BlogEntityCreateViewModel Model { get; }
}

public class PostBlogEntityCommandHandler : IRequestHandler<PostBlogEntityCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly BlogEntityDbContext _context;

    public PostBlogEntityCommandHandler(BlogEntityDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(PostBlogEntityCommand request, CancellationToken cancellationToken)
    {
        var blog = _mapper.Map<BlogEntity>(request.Model);

        var entity = await _context.Blogs.AddAsync(blog, cancellationToken)
            .ConfigureAwait(false);

        await _context.SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return entity.Entity.Id;
    }
}