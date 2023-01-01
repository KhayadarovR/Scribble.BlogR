using FluentValidation;
using Scribble.Blog.Web.Models;

namespace Scribble.Blog.Web.Features.Validators;

public class BlogEntityCreateViewModelValidator : AbstractValidator<BlogEntityCreateViewModel>
{
    public BlogEntityCreateViewModelValidator() => RuleSet("default", () =>
    {
        RuleFor(x => x.Title).NotNull().NotEmpty();
        RuleFor(x => x.Content).NotNull();
    });
}