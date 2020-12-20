using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string? Fullname { get; set; }
        public string? Mobileno { get; set; }

        //navigational:
        public ICollection<Task> Tasks { get; set; }
        public ICollection<TaskHistory> TaskHistories { get; set; }


    }
}
