﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Status
    {
        public byte Id { get; set; }

        [StringLength(15)]
        public string Name { get; set; }
    }
}