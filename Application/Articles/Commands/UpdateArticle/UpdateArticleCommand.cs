using System;
using MediatR;

namespace Application.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Content { get; set; }
    }
}
