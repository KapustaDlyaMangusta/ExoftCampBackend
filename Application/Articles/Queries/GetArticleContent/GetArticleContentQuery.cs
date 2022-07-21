using System;
using MediatR;

namespace Application.Articles.Queries.GetArticleContent
{
    public class GetArticleContentQuery : IRequest<ArticleContentVm>
    {
        public Guid Id { get; set; }
    }
}
