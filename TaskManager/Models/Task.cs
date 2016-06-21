using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Name { get; set; }


        public DateTime Deadline { get; set; }

        [Required]
        public byte StatusId { get; set; }

        public Status Status { get; set; }

        [Required]
        public byte PriorityId { get; set; }
        public Priority Priority { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}