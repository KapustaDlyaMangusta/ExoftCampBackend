
using Domain.Enums;
using System;

namespace Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }

    }
}
