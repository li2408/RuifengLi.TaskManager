﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Core.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public char? Priority { get; set; }
        public string? Remarks { get; set; }

        //navigational:
        public User User { get; set; }

    }
}
