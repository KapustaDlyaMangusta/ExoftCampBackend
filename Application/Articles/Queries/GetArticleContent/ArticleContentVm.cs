using Application.Common.Mappings;
using AutoMapper;
using Domain.Models;
using System;

namespace Application.Articles.Queries.GetArticleContent
{
    public class ArticleContentVm : IMapWith<Article>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? EditTime { get; set; }

        public User User { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Article, ArticleContentVm>();
        }
    }
}
