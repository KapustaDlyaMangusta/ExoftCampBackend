using System;
using Domain.Enums;
using MediatR;

namespace Application.Articles.Commands.VerifyArticle
{
    public class VerifyArticleCommand : IRequest
    {
        public Guid Id { get; set; }
        public State State { get; set; }
        public Guid UserId { get; set; }
        public Role Role { get; set; }
    }
}
