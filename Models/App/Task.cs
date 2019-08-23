﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeTracker.Models.App
{
    public class Task
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Min character required: 3")]
        public string Name { get; set; }
        [System.ComponentModel.DefaultValue("")]
        public string Description { get; set; }
        [Required]
        //custom to 2 decimal
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal TimeEstimateInHours { get; set; }
    }
}