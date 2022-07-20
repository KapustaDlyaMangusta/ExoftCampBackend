using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommandHandler 
        : IRequestHandler<UpdateArticleCommand>
    {
        private readonly IAppDbContext _dbContext;
        public UpdateArticleCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateArticleCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Articles.FirstOrDefaultAsync(
                    article => article.Id == request.Id, cancellationToken);
            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Article), request.Id);
            }

            entity.Title = request.Title;
            entity.Details = request.Details;
            entity.Content = request.Content;
            entity.EditTime = DateTime.Now;
            entity.State = State.Waiting;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
