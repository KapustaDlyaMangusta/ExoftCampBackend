using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using MediatR;

namespace Application.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandHandler
        :IRequestHandler<CreateArticleCommand, Guid>
    {
        private readonly IAppDbContext _dbContext;
        public CreateArticleCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateArticleCommand request,
            CancellationToken cancellationToken)
        {
            var article = new Article
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Content = request.Content,
                State = State.Waiting,
                EditTime = null
            };

            await _dbContext.Articles.AddAsync(article, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return article.Id;
        }
    }
}
