using FluentValidation;
using System;

namespace Application.Articles.Commands.UpdateArticle
{
    /* public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        public UpdateArticleCommandValidator()
        {
            RuleFor(createArticleCommand =>
                createArticleCommand.Title).NotEmpty().MaximumLength(200);
            RuleFor(createArticleCommand =>
                createArticleCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createArticleCommand =>
                createArticleCommand.Id).NotEqual(Guid.Empty);
            RuleFor(createArticleCommand =>
                createArticleCommand.Details).MaximumLength(400);
            RuleFor(createArticleCommand =>
                createArticleCommand.Content).NotEmpty();
        }
    } */
}
