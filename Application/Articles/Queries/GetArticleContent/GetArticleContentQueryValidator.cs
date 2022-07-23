using System;
using FluentValidation;

namespace Application.Articles.Queries.GetArticleContent
{
    public class GetArticleContentQueryValidator : AbstractValidator<GetArticleContentQuery>
    {
        GetArticleContentQueryValidator()
        { 
            RuleFor(createArticleCommand =>
                createArticleCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
