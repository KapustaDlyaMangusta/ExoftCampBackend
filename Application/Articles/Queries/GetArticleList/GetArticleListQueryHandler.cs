using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Articles.Queries.GetArticleList
{
    public class GetArticleListQueryHandler 
        : IRequestHandler<GetArticleListQuery, ArticleListVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetArticleListQueryHandler(IAppDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ArticleListVm> Handle(GetArticleListQuery request,
            CancellationToken cancellationToken)
        {
            var articleQuery = await _dbContext.Articles
                .Where(article => article.State == request.State)
                .ProjectTo<ArticleInfoDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ArticleListVm { Articles = articleQuery };
                
        }

    }
}
