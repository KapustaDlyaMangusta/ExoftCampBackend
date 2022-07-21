using FluentValidation;
using System;

namespace Application.Articles.Commands.VerifyArticle
{
    public class VerifyArticleCommandValidator : AbstractValidator<VerifyArticleCommand>
    {
        public VerifyArticleCommandValidator()
        {
            RuleFor(createArticleCommand =>
                createArticleCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createArticleCommand =>
                createArticleCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
