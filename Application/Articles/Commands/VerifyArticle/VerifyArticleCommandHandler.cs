using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Articles.Commands.VerifyArticle
{
    public class VerifyArticleCommandHandler 
        : IRequestHandler<VerifyArticleCommand>
    {
        private readonly IAppDbContext _dbContext;
        public VerifyArticleCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(VerifyArticleCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Articles.FirstOrDefaultAsync(
                    article => article.Id == request.Id, cancellationToken);
            if (entity == null)
            { 
                throw new NotFoundException(nameof(Article), request.Id);
            } 
            else if (request.Role != Domain.Enums.Role.Admin)
            {
                throw new NoRightsException(request.UserId);
            }

            entity.State = request.State;
            if(entity.CreationTime == null)
            {
                entity.CreationTime = DateTime.Now;
            }
            else
            {
                entity.EditTime = DateTime.Now;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
