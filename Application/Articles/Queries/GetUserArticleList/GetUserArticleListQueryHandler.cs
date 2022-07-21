using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Articles.Queries.GetUserArticleList
{
    public class GetUserArticleListQueryHandler 
        : IRequestHandler<GetUserArticleListQuery, ArticleListVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserArticleListQueryHandler(IAppDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ArticleListVm> Handle(GetUserArticleListQuery request,
            CancellationToken cancellationToken)
        {
            var articleQuery = await _dbContext.Articles
                .Where(article => article.UserId == request.UserId)
                .ProjectTo<ArticleInfoDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if(request.UserId == Guid.Empty)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            return new ArticleListVm { Articles = articleQuery };

        }
    }
}
