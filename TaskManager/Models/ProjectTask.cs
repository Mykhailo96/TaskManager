using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Deadline { get; set; }

        [Required]
        [Display(Name = "Status")]
        public byte StatusId { get; set; }
        public Status Status { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public byte PriorityId { get; set; }
        public Priority Priority { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}