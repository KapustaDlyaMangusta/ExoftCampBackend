using Application.Common.Mappings;
using AutoMapper;
using Domain.Models;
using System;

namespace Application.Articles.Queries
{
    public class ArticleInfoDto : IMapWith<Article>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? EditTime { get; set; }
        public User User { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Article, ArticleInfoDto>();
        }
    }
}
