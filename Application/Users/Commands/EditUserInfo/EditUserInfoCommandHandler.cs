using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.EditUserInfo
{
    public class EditUserInfoCommandHandler 
        : IRequestHandler<EditUserInfoCommand>
    {
        private readonly IAppDbContext _dbContext;
        public EditUserInfoCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(EditUserInfoCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
               await _dbContext.Users.FirstOrDefaultAsync(
                   user => user.UserId == request.UserId, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.AboutMe = request.AboutMe;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
