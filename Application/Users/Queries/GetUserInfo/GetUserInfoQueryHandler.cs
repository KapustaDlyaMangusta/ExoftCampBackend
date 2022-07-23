using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetUserInfo
{
    public class GetUserInfoQueryHandler 
        : IRequestHandler<GetUserInfoQuery, UserInfoVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserInfoQueryHandler(IAppDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserInfoVm> Handle(GetUserInfoQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users
                .FirstOrDefaultAsync(user =>
                user.UserId == request.UserId, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            return _mapper.Map<UserInfoVm>(entity);
        }
    }
}
