using System;
using MediatR;

namespace Application.Articles.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Content { get; set; }
    }
}
