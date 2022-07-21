using System;
using MediatR;

namespace Application.Articles.Queries.GetUserArticleList
{
    public class GetUserArticleListQuery : IRequest<ArticleListVm>
    {
        public Guid UserId { get; set; }
    }
}
