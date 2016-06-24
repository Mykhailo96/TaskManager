using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskManager.Models.Dto;

namespace TaskManager.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public IEnumerable<ProjectTaskDto> Tasks { get; set; }
    }
}