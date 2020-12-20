using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.Core.Models.Request
{
    public class TaskCreateRequestModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public char Priority { get; set; }

        [Required]
        [StringLength(500)]
        public string Remarks { get; set; }
    }
}
