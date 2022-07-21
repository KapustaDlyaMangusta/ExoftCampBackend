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

namespace Application.Articles.Queries.GetArticleContent
{
    public class GetArticleContentQueryHandler 
        : IRequestHandler<GetArticleContentQuery, ArticleContentVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetArticleContentQueryHandler(IAppDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
            
        public async Task<ArticleContentVm> Handle(GetArticleContentQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Articles
                .FirstOrDefaultAsync(article =>
                article.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Article), request.Id);
            }

            return _mapper.Map<ArticleContentVm>(entity);
        }
    }
}
