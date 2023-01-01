using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Scribble.Blog.Infrastructure.Contexts;
using Scribble.Blog.Models;
using Scribble.Blog.Web.Models;

namespace Scribble.Blog.Web.Features.Commands;

public class PutBlogEntityCommand : IRequest
{
    public PutBlogEntityCommand(BlogEntityUpdateViewModel model) =>
        Model = model;
    public BlogEntityUpdateViewModel Model { get; }
}

public class PutBlogEntityCommandHandler : IRequestHandler<PutBlogEntityCommand>
{
    private readonly IMapper _mapper;
    private readonly BlogEntityDbContext _context;

    public PutBlogEntityCommandHandler(IMapper mapper, BlogEntityDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Unit> Handle(PutBlogEntityCommand request, CancellationToken cancellationToken)
    {
        var blog = _mapper.Map<BlogEntity>(request.Model);

        _context.Blogs.Update(blog);

        await _context.SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return Unit.Value;
    }
}