using FluentValidation;
using System;

namespace Application.Users.Commands.EditUserInfo
{
    /* public class EditUserInfoCommandValidator : AbstractValidator<EditUserInfoCommand>
    {
        public EditUserInfoCommandValidator()
        {
            RuleFor(createArticleCommand =>
               createArticleCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createArticleCommand =>
                createArticleCommand.FirstName).NotEmpty().MaximumLength(50);         
            RuleFor(createArticleCommand =>
                createArticleCommand.LastName).NotEmpty().MaximumLength(50);
            RuleFor(createArticleCommand =>
                createArticleCommand.AboutMe).MaximumLength(400);
        }
    } */
}
