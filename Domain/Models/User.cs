﻿using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
