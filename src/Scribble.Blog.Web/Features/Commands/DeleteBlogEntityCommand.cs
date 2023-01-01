using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Scribble.Blog.Infrastructure.Contexts;
using Scribble.Blog.Infrastructure.Exceptions;
using Scribble.Blog.Models;
using Scribble.Blog.Web.Models;

namespace Scribble.Blog.Web.Features.Commands;

public class DeleteBlogEntityCommand : IRequest<BlogEntityViewModel>
{
    public DeleteBlogEntityCommand(Guid id) => Id = id;
    public Guid Id { get; }
}

public class DeleteBlogEntityCommandHandler : IRequestHandler<DeleteBlogEntityCommand, BlogEntityViewModel>
{
    private readonly IMapper _mapper;
    private readonly BlogEntityDbContext _context;

    public DeleteBlogEntityCommandHandler(BlogEntityDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BlogEntityViewModel> Handle(DeleteBlogEntityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Blogs
            .FindAsync(request.Id)
            .ConfigureAwait(false);

        if (entity == null)
            throw new MicroserviceEntityNotFoundException(typeof(BlogEntity),
                $"Entity with id '{request.Id}' not found");
        
        _context.Blogs.Remove(entity);

        return _mapper.Map<BlogEntityViewModel>(entity);
    }
}