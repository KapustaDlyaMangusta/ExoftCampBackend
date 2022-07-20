using System;
using Domain.Enums;
using MediatR;

namespace Application.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Role Role { get; set; }
    }
}
