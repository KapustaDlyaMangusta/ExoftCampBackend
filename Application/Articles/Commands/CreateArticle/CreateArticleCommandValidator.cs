using System;
using FluentValidation;

namespace Application.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            RuleFor(createArticleCommand =>
                createArticleCommand.Title).NotEmpty().MaximumLength(200);
            RuleFor(createArticleCommand =>
                createArticleCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createArticleCommand =>
                createArticleCommand.Details).MaximumLength(400);
            RuleFor(createArticleCommand =>
                createArticleCommand.Content).NotEmpty();

        }
    }
}
