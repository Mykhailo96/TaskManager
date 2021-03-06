﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Models.Dto
{
    public class ProjectTaskDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Name must have at least 5 letters")]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Deadline { get; set; }

        [Required]
        public byte StatusId { get; set; }
        public Status Status { get; set; }

        [Required]
        public byte PriorityId { get; set; }
        public Priority Priority { get; set; }
    }
}