using FluentValidation;
using System;

namespace Application.Articles.Commands.DeleteArticle
{
    */public class DeleteArticleCommandValidator : AbstractValidator<DeleteArticleCommand>
    {
        DeleteArticleCommandValidator()
        {
            RuleFor(createArticleCommand =>
                createArticleCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createArticleCommand =>
                createArticleCommand.Id).NotEqual(Guid.Empty);
        }
    }*/
}
