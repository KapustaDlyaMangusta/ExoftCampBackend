using Domain.Enums;
using MediatR;

namespace Application.Articles.Queries.GetArticleList
{
    public class GetArticleListQuery : IRequest<ArticleListVm>
    {
        public State State { get; set; }
    }
}
