using Domain.Enums;
using System;

namespace Domain.Models
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Content { get; set; }
        public State State { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? EditTime { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
