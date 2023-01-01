using MediatR;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Scribble.Blog.Infrastructure.Contexts;
using Scribble.Blog.Web.Models;

namespace Scribble.Blog.Web.Features.Queries;

public class GetBlogByIdQuery : IRequest<BlogEntityViewModel>
{
    public GetBlogByIdQuery(Guid id) => Id = id;
    public Guid Id { get; }
}

public class GetBlogIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogEntityViewModel>
{
    private readonly IMapper _mapper;
    private readonly BlogEntityDbContext _context;

    public GetBlogIdQueryHandler(BlogEntityDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BlogEntityViewModel> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Blogs
            .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken)
            .ConfigureAwait(false);

        return _mapper.Map<BlogEntityViewModel>(entity);
    }
}