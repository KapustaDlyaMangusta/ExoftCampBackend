using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using MediatR;

namespace Application.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommandHandler 
        : IRequestHandler<DeleteArticleCommand>
    {
        private readonly IAppDbContext _dbContext;
        public DeleteArticleCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteArticleCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Articles
                .FindAsync(new object[] {request.Id}, cancellationToken);
            
            if (entity == null)
            {
                throw new NotFoundException(nameof(Article), request.Id);
            }
            else if(entity.UserId != request.UserId || request.Role != Role.Admin)
            {
                throw new NoRightsException(request.UserId);
            }

            _dbContext.Articles.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
